namespace Restee.Meta {

    public interface IMetadataProvider<TResource>  {


        ResourceMeta Get(string get);

    }

}