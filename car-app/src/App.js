import 'bootstrap/dist/css/bootstrap.css';
import React, { useState } from 'react';
import { Nav, NavItem, NavLink } from "reactstrap";
import './App.css';
import Car from './Components/Car';

function App() {

    const [mostrarCar, setMostrarCar] = useState(false);
  return (
      <div className="sidebar">
          <Nav tabs>
              <NavItem>
                  <NavLink href="#" onClick={() => setMostrarCar(true)}>Modelo Carros</NavLink>
              </NavItem>
              <NavItem>
                  <NavLink href="#">Modelo Categorias</NavLink>
              </NavItem>
          </Nav>
          {mostrarCar && <Car />} {/* Mostrar el componente Car cuando mostrarCar sea true */}
    </div>
  );
}

export default App;
