export interface IPagination {
  Page: number;
  Limit: number;
  Filter?: string;
  FilterBy?: string;
  Sort?: string;
  Order?: string;
}
