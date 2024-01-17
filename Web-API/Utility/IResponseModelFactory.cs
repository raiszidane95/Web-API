using Web_API.Model;

namespace Web_API.Utility;


    public interface IResponseModelFactory<TEntity>
    {
        ResponseModel<TEntity> CreateOK(int code, TEntity data);
        ResponseModel<TEntity> CreateOK(int code, string message);
        ResponseModel<TEntity> CreateWarning(int code, string message = null);
        ResponseModel<TEntity> CreateWarning<T>(int code);
        ResponseModel<TEntity> CreateError(int code, string message=null);
        ResponseModel<TEntity> CreateError(int code, IEnumerable<TEntity> data = null);

    }