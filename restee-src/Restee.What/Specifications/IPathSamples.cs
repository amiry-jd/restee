using System.Threading.Tasks;

namespace Restee.What.Specifications {

    public interface IPathSamples {

        Task<ResponseModel> WithoutPattern();

        Task<ResponseModel> WithSimplePattern();

        Task<ResponseModel> WithOneSegment();

        Task<ResponseModel> WithTowSegments();

        Task<ResponseModel> WithTowSegmentsDeparted();

        Task<ResponseModel> WithOneSegmentAndNamedParam();

        Task<ResponseModel> WithTowSegmentsAndNamedParam();

        Task<ResponseModel> WithTowSegmentsDepartedAndNamedParam();

    }

}