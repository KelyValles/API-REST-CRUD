import 'bootstrap/dist/css/bootstrap.css';
import React, { useState } from 'react';
import { Nav, NavItem, NavLink } from "reactstrap";
import './App.css';
import Car from './Components/Car';
import Category from './Components/Category';

function App() {

    const [mostrarCar, setMostrarCar] = useState(false);
    const [mostrarCategory, setMostrarCategory] = useState(false);

  return (
      <div className="sidebar">
          <Nav tabs>
              <NavItem>
                  <NavLink href="#" onClick={() => {
                      setMostrarCar(true);
                      setMostrarCategory(false); // Asegurar que mostrarCategory sea false
                  }}>
                      Modelo Carros
                  </NavLink>
              </NavItem>
              <NavItem>
                  <NavLink href="#" onClick={() => {
                      setMostrarCar(false); 
                      setMostrarCategory(true);
                  }}>
                      Modelo Categorías
                  </NavLink>
              </NavItem>
          </Nav>
          {mostrarCar && <Car />} {/* Mostrar el componente Car cuando mostrarCar sea true */}
          {mostrarCategory && <Category /> }
    </div>
  );
}

export default App;
