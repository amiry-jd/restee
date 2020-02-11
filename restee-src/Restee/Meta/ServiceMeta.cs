using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

using Restee.Attributes;

namespace Restee.Meta {

    public static class MetaHelper {

        public static string? GetBaseUrl(this IEnumerable<Attribute> attributes) {
            var attr = attributes.Single(a => a is ResteeAttribute) as ResteeAttribute;
            return attr?.BaseUrl;
        }

        public static Type GetDeserializer(this IEnumerable<Attribute> attributes) {
            var attr = attributes.SingleOrDefault(a => a is DeserializerAttribute) as DeserializerAttribute;

            return attr?.DeserializerType;
        }

        public static Type GetSerializer(this IEnumerable<Attribute> attributes) {
            var attr = attributes.SingleOrDefault(a => a is SerializerAttribute) as SerializerAttribute;

            return attr?.SerializerType;
        }

        public static (Type serializer, Type deserializer) GetSerializationMeta(this IEnumerable<Attribute> attributes) {
            var serAttr = attributes.SingleOrDefault(a => a is SerializerAttribute) as SerializerAttribute;
            var desAttr = attributes.SingleOrDefault(a => a is DeserializerAttribute) as DeserializerAttribute;

            return (serAttr?.SerializerType, desAttr?.DeserializerType);
        }

        public  static (HttpMethod method, string path) GetHttpMethod(this IEnumerable<Attribute> attributes) {
            var attr = attributes.SingleOrDefault(a => a is HttpMethodAttribute) as HttpMethodAttribute;

            return (attr?.HttpMethod, attr?.Path);
        }

        public static IReadOnlyDictionary<string, string> GetHeaders(this  IEnumerable<Attribute> attributes) {
            return attributes //.Where(a => a is HeaderAttribute)
                  .OfType<HeaderAttribute>()
                  .ToDictionary(a => a.Name, a => a.Value);
        }

    }

    /// <summary>
    /// Any service point that contains one or more endpoints to act on a remote-entity called a resource. See:
    /// <para>
    /// The key abstraction of information in REST is a resource. Any information that can be named can be a resource:
    /// a document or image, a temporal service (e.g. “today’s weather in Los Angeles”), a collection of other resources,
    /// a non-virtual object (e.g., a person), and so on. In other words, any concept that might be the target of an author’s
    /// hypertext reference must fit within the definition of a resource. A resource is a conceptual mapping to a set of entities,
    /// not the entity that corresponds to the mapping at any particular point in time.
    /// (Roy Fielding’s dissertation (https://www.ics.uci.edu/~fielding/pubs/dissertation/rest_arch_style.htm#sec_5_2_1_1))
    /// </para>
    /// </summary>
    public class ResourceMeta {

        public string BaseUrl { get; }
        public Type SerializerType { get; }
        public Type DeserializerType { get; }
        public IReadOnlyDictionary<string, string> Headers { get; }
        public IEnumerable<OperationMeta> OperationMetas { get; }

        public ResourceMeta(Type resourceType) {
            var attributes = resourceType.GetCustomAttributes().ToList();
            BaseUrl = attributes.GetBaseUrl();
            SerializerType = attributes.GetSerializer();
            DeserializerType = attributes.GetDeserializer();
            Headers = attributes.GetHeaders();
            OperationMetas = resourceType.GetMethods()
                                         .Select(method => new OperationMeta(this, method))
                                         .ToList();
        }
    }

    public class OperationMeta {

        public ResourceMeta ResourceMeta { get; }
        public HttpMethod HttpMethod { get; }
        public string Path { get; }
        public Type SerializerType { get; }
        public Type DeserializerType { get; }
        public IReadOnlyDictionary<string, string> Headers { get; }
        public IEnumerable<FactorMeta> FactorMetas { get; }
        public string Sig { get; }

        public OperationMeta(ResourceMeta resourceMeta, MethodInfo method) {
            ResourceMeta = resourceMeta;
            var attributes = method.GetCustomAttributes().ToList();
            (HttpMethod, Path) = attributes.GetHttpMethod();
            (SerializerType, DeserializerType) = attributes.GetSerializationMeta();
            Headers = attributes.GetHeaders();
            FactorMetas = method.GetParameters().Select(param => new FactorMeta(this, param)).ToList();
            Sig = method.Name + '_' +
                   string.Join('_',
                               FactorMetas.Select(f => f.ParameterType.FullName ?? f.ParameterType.Name));
        }


    }

    public class FactorMeta {

        public OperationMeta OperationMeta { get; }
        public FactorKind Kind { get; }
        public Type ParameterType { get; }
        public string ParameterName { get; }
        public string FactorName { get; }
        public string KeyAlias { get; }

        public FactorMeta(OperationMeta operationMeta, ParameterInfo parameterInfo) {
            OperationMeta = operationMeta;
            var attributes = parameterInfo.GetCustomAttributes();
            var attr = attributes.SingleOrDefault(a => a is FactorAttribute) as FactorAttribute;
            Kind = attr?.FactorKind ?? FactorKind.Query;
            ParameterType = parameterInfo.ParameterType;
            ParameterName = parameterInfo.Name;
            FactorName = attr?.Name;
            KeyAlias = string.IsNullOrWhiteSpace(FactorName) ? ParameterName : FactorName;
        }


    }

}