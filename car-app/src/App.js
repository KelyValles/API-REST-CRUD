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
          {mostrarCategory && <Category />}
          <div>
              <h1>Hola!</h1>
              <p>Bienvenido a su nueva aplicación, construida con:</p>
              <ul>
                  <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> para código del lado del servidor multiplataforma</li>
                  <li><a href='https://facebook.github.io/react/'>React</a> para el código del lado del cliente</li>
                  <li><a href='http://getbootstrap.com/'>Bootstrap</a> para maquetación y estilo</li>
              </ul>
              
              <ul>
                  <li><a href='https://github.com/KelyValles/API.git'>Github</a> Código fuente</li>

              </ul>
              
          </div>
      </div>

  );
}

export default App;
