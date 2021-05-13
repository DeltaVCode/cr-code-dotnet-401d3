import { useState } from 'react';
import { Switch, Route, NavLink } from 'react-router-dom';
import Home from './components/Home';
import BootstrapDemo from './components/BootstrapDemo';
import FormDemo from './components/FormDemo'
import NavLogin from './components/NavLogin';
import Login from './components/auth/Login';
import './App.css';

function App() {
  const [user, setUser] = useState({ name: 'Keith' });

  return (
    <div className="App">
      <nav>
        <ul>
          <li><NavLink to="/" exact>Home</NavLink></li>
          <li><NavLink to="/forms">Form Demo</NavLink></li>
          <li><NavLink to="/bootstrap">Bootstrap</NavLink></li>
          <NavLogin user={user} />
        </ul>
      </nav>
      <main>
        <Switch>
          <Route path="/" exact>
            <Home />
          </Route>
          <Route path="/bootstrap">
            <BootstrapDemo user={user} />
          </Route>
          <Route path="/forms">
            <FormDemo />
          </Route>
          <Route path="/login">
            <Login />
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
