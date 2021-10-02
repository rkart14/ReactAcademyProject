import { ITableProps } from "./TableProps";

export interface IGridManagement{
    items: IGridItem[];
    width: number;
    height: number;
}

export interface IGridItem{
    index: number;
    table: ITableProps;
    isTableInitialized: boolean;
}