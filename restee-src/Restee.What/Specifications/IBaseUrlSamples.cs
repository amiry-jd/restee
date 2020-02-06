namespace Restee.What.Specifications
{

    public class ResponseModel{}

    [RestEra]
    public interface IBaseUrlNone { }

    [RestEra]
    public interface IBaseUrlEmpty { }
    
    [RestEra("https://api.manexapp.com")]
    public interface IBaseUrlWithUrlValue{}

    public interface IBaseUrlWithKey { }

    [RestEra]
    public interface IBaseUrlNoneWithHeader { }

    [RestEra]
    public interface IBaseUrlEmptyWithHeader { }

    [RestEra("https://api.manexapp.com")]
    public interface IBaseUrlWithUrlValueWithHeader { }

    public interface IBaseUrlWithKeyWithHeader { }

    [RestEra]
    public interface IBaseUrlNoneWithHeaderWithDeserializer { }

    [RestEra]
    public interface IBaseUrlEmptyWithHeaderWithDeserializer { }

    [RestEra("https://api.manexapp.com")]
    public interface IBaseUrlWithUrlValueWithHeaderWithDeserializer { }

    public interface IBaseUrlWithKeyWithHeaderWithDeserializer { }


}