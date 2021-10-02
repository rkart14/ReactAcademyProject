import { FC } from "react";
import { useDrop } from "react-dnd";
import { IGridItem } from "../../models/TableManagementState";
import { ItemTypes } from "./consts/ItemTypes";
import "./grid-item.css"
import { Table } from "./table";

export const GridItem: FC<IGridItem> = (item) => {
    const [{ isOver }, drop] = useDrop(() => ({
        accept: ItemTypes.TABLE,
        drop: () => console.log("moved to" + item.index),
        canDrop: ()=> !item.isTableInitialized,
        collect: monitor => ({
            isOver: !!monitor.isOver(),
        }),
    }))

    return (
        <div className="grid-item" ref={drop}>
            <Table
                table={item.table}
                isTableInitialized={item.isTableInitialized}
                index={item.index}
            >
            </Table>
        </div>
    )
}