export interface ApiResult<T>{
  data: T[];
  pageIndex: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  sortOrder: string;
  filterQuery: string;
}
