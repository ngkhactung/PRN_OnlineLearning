﻿namespace Online_Learning.Models.DTOs.Response.Common
{
	public class PaginatedResponse<T>
	{
		public IEnumerable<T> Data { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
		public int TotalPages { get; set; }
		public bool HasNextPage { get; set; }
		public bool HasPreviousPage { get; set; }
	}
}