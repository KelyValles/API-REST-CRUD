import React, { useEffect, useState } from 'react';
import { Modal, ModalHeader, ModalBody, Form, FormGroup, Input, ModalFooter, Button } from "reactstrap"
import PropTypes from 'prop-types';

const modeloCar = {
    category: "",
    brand: "",
    model: "",
    color: "",
    engineType: ""
}

const ModalCar = ({ mostrarModal, setmostrarModal, guardarCar, actualizar, setActualizar, actualizarCar }) => {
    ModalCar.propTypes = {
        mostrarModal: PropTypes.bool,
        setmostrarModal: PropTypes.func,
        guardarCar: PropTypes.func,
        actualizar: PropTypes.object,
        setActualizar: PropTypes.func,
        actualizarCar: PropTypes.func,


    };

    const [car, setCar] = useState(modeloCar);

    const actualizarDatos = (e) => {
        console.log(e.target.name + " : " + e.target.value);
        setCar(
            {
                ...car,
                [e.target.name]: e.target.value

            }
        )
    }

    const enviarDatos = () => {

        if (car.id == null) {
            guardarCar(car)
            setCar(modeloCar)
        } else {
            actualizarCar(car)
            console.log('++', actualizarCar)
        }
        
    }

    useEffect(() => {
        if (actualizar != null) {
            setCar(actualizar)
            console.log('*', actualizar)
        } else {
            setCar(modeloCar)
            
        }
    }, [actualizar])

    const cerrarModal = () => {
        setmostrarModal(!mostrarModal)
        setActualizar(null)
    }

    return (
        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                {car.id == null ? "Registrar Carro" : "Actualizar Carro"}

            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <label>Categoria</label>
                        <Input name="category" onChange={(e) => actualizarDatos(e)} value={car.category} />
                    </FormGroup>
                    <FormGroup>
                        <label>Marca</label>
                        <Input name="brand" onChange={(e) => actualizarDatos(e)} value={car.brand} />
                    </FormGroup>
                    <FormGroup>
                        <label>Modelo</label>
                        <Input name="model" onChange={(e) => actualizarDatos(e)} value={car.model} />
                    </FormGroup>
                    <FormGroup>
                        <label>Color</label>
                        <Input name="color" onChange={(e) => actualizarDatos(e)} value={car.color} />
                    </FormGroup>
                    <FormGroup>
                        <label>Tipo de motor</label>
                        <Input name="engineType" onChange={(e) => actualizarDatos(e)} value={car.engineType} />
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarDatos} >Guardar</Button>
                <Button color="danger" size="sm" onClick={cerrarModal}>Cerrar</Button>


            </ModalFooter>
        </Modal>
    )
}

export default ModalCar;