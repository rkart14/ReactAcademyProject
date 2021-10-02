import './App.css';
import { Grid } from './features/shared/grid';
import { IGridItem, IGridManagement } from './models/TableManagementState';
import { ITableProps } from './models/TableProps';

function App() {
  const grid = {
    items: [],
    width: 15,
    height: 10
  } as IGridManagement;
  for (var i = 0; i < 150; i++){
    grid.items.push({
      index: i,
      table: { numberOfSeats : i%6 + 2} as ITableProps,
      isTableInitialized: i % 7== 0
      } as IGridItem)
  }
  return (

    <Grid items={grid.items} width={grid.width} height={grid.height}>
    </Grid>
  );
}

export default App;
