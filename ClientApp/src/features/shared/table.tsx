import { FC } from "react"
import { useDrag } from "react-dnd"
import { IGridItem } from "../../models/TableManagementState"
import { ItemTypes } from "./consts/ItemTypes"

export const Table: FC<IGridItem> = ({ table, isTableInitialized, index }) => {
    const [{ isDragging }, drag] = useDrag(() => ({
        type: ItemTypes.TABLE,
        canDrag: () => isTableInitialized,
        collect: monitor => ({
            isDragging: !!monitor.isDragging(),
        }),
    }))

    return (
        <div className="item-container" ref={drag}>
            {
                isTableInitialized ?
                    <div>
                        <span className="number-seats-label">{table.numberOfSeats}</span>
                    </div>
                    :
                    <div className="empty-item">
                        Empty
                    </div>
            }
        </div>
    )
}