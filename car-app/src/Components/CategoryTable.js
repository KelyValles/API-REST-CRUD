import React from 'react';
import { Button, Table } from "reactstrap";
import PropTypes from 'prop-types';


const CategoryTable = ({ data, setActualizar, mostrarModal, setmostrarModal, eliminarCategory }) => {
    CategoryTable.propTypes = {
        data: PropTypes.arrayOf(
            PropTypes.shape({
                name: PropTypes.string.isRequired,
                description: PropTypes.string.isRequired,
                
            })
        ).isRequired,
        setActualizar: PropTypes.func,
        mostrarModal: PropTypes.bool,
        setmostrarModal: PropTypes.func,
        eliminarCategory: PropTypes.func,


    };

    const enviarDatos = (category) => {
        setActualizar(category)
        setmostrarModal(!mostrarModal)
    }

    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Descripción</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="7">Sin registros</td>
                        </tr>
                    ) : (
                        data.map((item) => (

                            <tr key={item.id}>

                                <td>{item.name}</td>
                                <td>{item.description}</td>
                                
                                <td>
                                    <Button color="primary" size="sm" className="me-2"
                                        onClick={() => enviarDatos(item)}
                                    >Actualizar</Button>
                                    <Button color="danger" size="sm"
                                        onClick={() => eliminarCategory(item.id)}
                                    >Eliminar</Button>

                                </td>
                            </tr>
                        )
                        )
                    )
                }
            </tbody>
        </Table>



    )
}
export default CategoryTable;