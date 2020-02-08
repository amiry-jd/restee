using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

using Restee.Attributes;

namespace Restee.Meta {

    public static class MetaHelper {

        public static string? GetBaseUrl(this IEnumerable<Attribute> attributes) {
            var attr = attributes.Single(a => a is RestEraAttribute) as RestEraAttribute;
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

        public static IDictionary<string, string> GetHeaders(this  IEnumerable<Attribute> attributes) {
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

        private readonly string                      _baseUrl;
        private readonly Type                        _serializerType;
        private readonly Type                        _deserializerType;
        private readonly IDictionary<string, string> _headers;

        public ResourceMeta(Type resourceType) {
            var attributes = resourceType.GetCustomAttributes().ToList();
            _baseUrl = attributes.GetBaseUrl();
            _serializerType = attributes.GetSerializer();
            _deserializerType = attributes.GetDeserializer();
            _headers = attributes.GetHeaders();
            var methodMetas = GetMethodMetas(resourceType, attributes);
        }

        private object GetMethodMetas(Type resourceType, List<Attribute> attributes) {
            var methods = resourceType.GetMethods();
            var list = new List<MethodMeta>();
            foreach (var method in methods) list.Add(new MethodMeta(this, resourceType, attributes, method));
            return list;
        }

    }

    internal class MethodMeta {

        private readonly ResourceMeta _resourceMeta;
        private readonly HttpMethod _httpMethod;
        private readonly string _path;
        private readonly Type _serializerType;
        private readonly Type _deserializerType;
        private readonly IDictionary<string, string> _headers;

        public MethodMeta(ResourceMeta resourceMeta, Type resourceType, List<Attribute> resourceAttributes, MethodInfo method) {
            _resourceMeta = resourceMeta;
            var attributes = method.GetCustomAttributes().ToList();
            (_httpMethod, _path) = attributes.GetHttpMethod();
            (_serializerType, _deserializerType) = attributes.GetSerializationMeta();
            _headers = attributes.GetHeaders();
            var parameters = GetParameterMetas(method );
        }

        private object GetParameterMetas(MethodInfo method) {
            var parameters = method.GetParameters();
            var list=new List<ParameterMeta>();
            foreach (var param in parameters) list.Add(new ParameterMeta(this, param));

            return list;
        }

    }

    internal class ParameterMeta {

        private readonly MethodMeta _methodMeta;
        private readonly ParamType _paramType;
        private readonly string _name;
        private readonly string _metaName;
        private readonly Type _type;

        public ParameterMeta(MethodMeta methodMeta, ParameterInfo parameterInfo) {
            _methodMeta = methodMeta;
            var attributes = parameterInfo.GetCustomAttributes();
            var attr = attributes.SingleOrDefault(a => a is ParamAttribute) as ParamAttribute;
            _paramType = attr?.ParamType ?? ParamType.Query;
            _name = parameterInfo.Name;
            _metaName = attr?.Name;
            _type = parameterInfo.ParameterType;
        }

    }

}