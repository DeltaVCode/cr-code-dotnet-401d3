import { Switch, Route, NavLink } from 'react-router-dom';
import Home from './components/Home';
import BootstrapDemo from './components/BootstrapDemo';
import FormDemo from './components/FormDemo'
import './App.css';

function App() {
  return (
    <div className="App">
      <nav>
        <ul>
          <li><NavLink to="/" exact>Home</NavLink></li>
          <li><NavLink to="/forms">Form Demo</NavLink></li>
          <li><NavLink to="/bootstrap">Bootstrap</NavLink></li>
        </ul>
      </nav>
      <main>
        <Switch>
          <Route path="/" exact>
            <Home />
          </Route>
          <Route path="/bootstrap">
            <BootstrapDemo />
          </Route>
          <Route path="/forms">
            <FormDemo />
          </Route>
          <Route>
            <h1>Not Found</h1>
          </Route>
        </Switch>
      </main>
    </div>
  );
}

export default App;
