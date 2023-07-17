import React, { useEffect, useState } from 'react';
import { Modal, ModalHeader, ModalBody, Form, FormGroup, Input, ModalFooter, Button } from "reactstrap"
import PropTypes from 'prop-types';

const modeloCategory = {
    name: "",
    description: "",
    
}

const ModalCategory = ({ mostrarModal, setmostrarModal, guardarCategory, actualizar, setActualizar, actualizarCategory }) => {
    ModalCategory.propTypes = {
        mostrarModal: PropTypes.bool,
        setmostrarModal: PropTypes.func,
        guardarCategory: PropTypes.func,
        actualizar: PropTypes.object,
        setActualizar: PropTypes.func,
        actualizarCategory: PropTypes.func,


    };

    const [category, setCategory] = useState(modeloCategory);

    const actualizarDatos = (e) => {
        console.log(e.target.name + " : " + e.target.value);
        setCategory(
            {
                ...category,
                [e.target.name]: e.target.value

            }
        )
    }

    const enviarDatos = () => {

        if (category.id == null) {
            guardarCategory(category)
            setCategory(modeloCategory)
        } else {
            actualizarCategory(category)
            console.log('++', actualizarCategory)
        }

    }

    useEffect(() => {
        if (actualizar != null) {
            setCategory(actualizar)
            console.log('*', actualizar)
        } else {
            setCategory(modeloCategory)

        }
    }, [actualizar])

    const cerrarModal = () => {
        setmostrarModal(!mostrarModal)
        setActualizar(null)
    }

    return (
        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                {category.id == null ? "Registrar Categoría" : "Actualizar Categoría"}

            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <label>Nombre</label>
                        <Input name="name" onChange={(e) => actualizarDatos(e)} value={category.name} />
                    </FormGroup>
                    <FormGroup>
                        <label>Descripción</label>
                        <Input name="description" onChange={(e) => actualizarDatos(e)} value={category.description} />
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

export default ModalCategory;