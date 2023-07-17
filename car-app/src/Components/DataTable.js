import React from 'react';
import { Button, Table } from "reactstrap";
import PropTypes from 'prop-types';


const DataTable = ({ data, setActualizar, mostrarModal, setmostrarModal, eliminarCar }) => {
    DataTable.propTypes = {
        data: PropTypes.arrayOf(
            PropTypes.shape({
                category: PropTypes.string.isRequired,
                brand: PropTypes.string.isRequired,
                model: PropTypes.string.isRequired,
                color: PropTypes.string.isRequired,
                engineType: PropTypes.string.isRequired
            })
        ).isRequired,
        setActualizar: PropTypes.func,
        mostrarModal: PropTypes.bool,
        setmostrarModal: PropTypes.func,
        eliminarCar: PropTypes.func,


    };

    const enviarDatos = (car) => {
        setActualizar(car)
        setmostrarModal(!mostrarModal)
    }

    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>Categoria</th>
                    <th>Marca</th>
                    <th>Modelo</th>
                    <th>Color</th>
                    <th>Tipo de motor</th>
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

                                <td>{item.category}</td>
                                <td>{item.brand}</td>
                                <td>{item.model}</td>
                                <td>{item.color}</td>
                                <td>{item.engineType}</td>
                                <td>
                                    <Button color="primary" size="sm" className="me-2"
                                        onClick={() => enviarDatos(item)}
                                    >Actualizar</Button>
                                    <Button color="danger" size="sm"
                                        onClick={() => eliminarCar(item.id)}
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
export default DataTable;