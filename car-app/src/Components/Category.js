import { Container, Row, Col, Card, CardHeader, CardBody, Button } from "reactstrap"
import CategoryTable from './CategoryTable';
import React, { useEffect, useState } from 'react';
import ModalCategory from './ModalCategory';

function Category() {
    const [category, setCategory] = useState([]);
    const [mostrarModal, setmostrarModal] = useState(false);
    const [actualizar, setActualizar] = useState(null);

    const mostrarCategory = async () => {
        const response = await fetch("https://localhost:7121/api/Categories");
        if (response.ok) {
            const data = await response.json();
            setCategory(data);
            console.log("mostrar", data);
        } else {
            console.log("Error en la petición listado carros")
        }
    }

    useEffect(() => {
        mostrarCategory()
    }, [])

    const guardarCategory = async (category) => {
        const response = await fetch('https://localhost:7121/api/Categories', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(category)
        })
        if (response.ok) {
            setmostrarModal(!mostrarModal);
            mostrarCategory();
        }
    }

    const actualizarCategory = async (category) => {
        const { id, ...categoryData } = category; // Desestructurar el campo `id` del objeto `car`
        console.log("here", category);
        const url = `https://localhost:7121/api/Categories/${category.id}`;
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(categoryData)

        });

        if (response.ok) {
            setmostrarModal(!mostrarModal);
            mostrarCategory();
        }
    }

    const eliminarCategory = async (id) => {

        var respuesta = window.confirm("¿Desea eliminar la categoría?")
        if (!respuesta) {
            return;
        }
        const url = `https://localhost:7121/api/Categories/${id}`;
        const response = await fetch(url, {
            method: 'DELETE'
        });
        if (response.ok) {
            mostrarCategory();
        }
    }
    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>

                        <CardHeader>
                            <h5>Listado de Categorías</h5>
                        </CardHeader>
                        <CardBody>

                            <Button size="sm" color="success"
                                onClick={() => setmostrarModal(!mostrarModal)}
                            >Registrar Categoría</Button>
                            <hr></hr>
                            <CategoryTable data={category}
                                setActualizar={setActualizar}
                                mostrarModal={mostrarModal}
                                setmostrarModal={setmostrarModal}

                                eliminarCategory={eliminarCategory}
                            />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <ModalCategory
                mostrarModal={mostrarModal}
                setmostrarModal={setmostrarModal}
                guardarCategory={guardarCategory}

                actualizar={actualizar}
                setActualizar={setActualizar}
                actualizarCategory={actualizarCategory}
            />
        </Container>
    )
}
export default Category;