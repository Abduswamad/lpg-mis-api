﻿namespace Gas.Utils.Interface
{
    public interface IResult<T>
    {
        string Message { get; set; }

        bool Succeeded { get; set; }

        T Data { get; set; }

        int Code { get; set; }
    }
}
