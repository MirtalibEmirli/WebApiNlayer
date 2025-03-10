namespace Common.GlobalResponses;

public class ResponseModel
{
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; }


    public ResponseModel(List<string> errors)
    {
        IsSuccess = false;
        Errors = errors;
    }

    public ResponseModel()
    {
        IsSuccess = true;
        Errors = null;
    }
}

