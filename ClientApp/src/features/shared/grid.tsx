import { FC } from "react";
import { DndProvider } from "react-dnd";
import { HTML5Backend } from "react-dnd-html5-backend";
import { IGridManagement } from "../../models/TableManagementState";
import { GridItem } from "./grid-item";
import "./grid.css"

export const Grid: FC<IGridManagement> = (grid) => {

    function renderItem(index: number) {
        return (
            <div key={index} className="grid-item-container">
                <GridItem
                    index={index}
                    isTableInitialized={grid.items[index].isTableInitialized}
                    table={grid.items[index].table} >
                </GridItem>
            </div>
        )
    }
    const items = []
    for (let index = 0; index < grid.width * grid.height; index++) {
        items.push(renderItem(index));
    }
    return <DndProvider backend={HTML5Backend}>
        <div className="grid-container">{items}</div>
    </DndProvider>;
}