﻿using GlobalExceptionHandler.Filters;

namespace SystemManagementFactory.Responses;

public record PaginationResponse<T> : BaseFilter
{
    public int TotalPages { get; init; }

    public int TotalRecords { get; init; }

    public T? Data { get; init; }

    public PaginationResponse(int pageNumber, int pageSize, int totalRecords, T? data) : base(pageNumber,pageSize)
    {
        Data = data;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
    }

    public static PaginationResponse<T> Create(int pageNumber, int pageSize, int totalRecords, T? data)
        => new(pageNumber, pageSize, totalRecords, data);
}