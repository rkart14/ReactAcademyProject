import './App.css';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import login from './features/account/login';
import register from './features/account/register';
import onBoarding from './features/account/on-boarding';
import tableLayoutEditor from './features/table-management/table-layout-editor';
import reporting from './features/reporting-management/reporting';
import reservationManagement from './features/reservation-management/reservation-management';

function App() {
 
  return (
     <Router>
        <div>
          <Switch>
              <Route exact path='/login' component={login} />
              <Route exact path='/register' component={register} />
              <Route exact path='/on-boarding' component={onBoarding} />
              <Route exact path='/layout-editor' component={tableLayoutEditor} />
              <Route exact path='/reservartion-management' component={reservationManagement} />
              <Route exact path='/reports' component={reporting} />

          </Switch>
        </div>
      </Router>
  );
}

export default App;
