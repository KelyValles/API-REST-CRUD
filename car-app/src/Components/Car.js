import { Container, Row, Col, Card, CardHeader, CardBody, Button } from "reactstrap"
import DataTable from './DataTable';
import React, { useEffect, useState } from 'react';
import ModalForm from './ModalForm';

function Car() {
    const [car, setCar] = useState([]);
    const [mostrarModal, setmostrarModal] = useState(false);
    const [actualizar, setActualizar] = useState(null);

    const mostrarCar = async () => {
        const response = await fetch("https://localhost:7121/api/Car");
        if (response.ok) {
            const data = await response.json();
            setCar(data);
        } else {
            console.log("Error en la petición listado carros")
        }
    }

    useEffect(() => {
        mostrarCar()
    },[])

    const guardarCar = async (car) => {
        const response = await fetch('https://localhost:7121/api/Car', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(car)
        })
        if (response.ok) {
            setmostrarModal(!mostrarModal);
            mostrarCar();
        }
    }

    const actualizarCar = async (car) => {
        console.log("here",car);
        const url = `https://localhost:7121/api/Car/${car.id}`; 
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(car)
            
        });
        
        if (response.ok) {
            setmostrarModal(!mostrarModal);
            mostrarCar();
        }
    }

    const eliminarCar = async (id) => {

        var respuesta = window.confirm("¿Desea eliminar el carro?")
        if (!respuesta) {
            return;
        }
        const url = `https://localhost:7121/api/Car/${id}`;
        const response = await fetch(url, {
            method: 'DELETE'
        });
        if (response.ok) {
            mostrarCar();
        }
    }
    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>

                        <CardHeader>
                            <h5>Listado de Carros</h5>
                        </CardHeader>
                        <CardBody>

                            <Button size="sm" color="success"
                                onClick={() => setmostrarModal(!mostrarModal)}
                            >Nuevo Carro</Button>
                            <hr></hr>
                            <DataTable data={car}
                                setActualizar={setActualizar}
                                mostrarModal={mostrarModal}
                                setmostrarModal={setmostrarModal}

                                eliminarCar={eliminarCar}
                            />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <ModalForm
                mostrarModal={mostrarModal}
                setmostrarModal={setmostrarModal}
                guardarCar={guardarCar}

                actualizar={actualizar}
                setActualizar={setActualizar}
                actualizarCar={actualizarCar}
            />
        </Container>
    )
}
export default Car;