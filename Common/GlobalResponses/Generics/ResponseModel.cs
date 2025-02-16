﻿namespace Common.GlobalResponses.Generics;

public class ResponseModel<T> : ResponseModel
{
    public T? Data { get; set; }
    public ResponseModel()
    {
        
    }
    public ResponseModel(List<string> messages ):base(messages) 
    {
        
    }
}
