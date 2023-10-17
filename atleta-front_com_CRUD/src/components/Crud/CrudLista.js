import React from "react";
import { Link } from "react-router-dom";
import CrudAcao from './CrudAcao';

const CrudLista = (props) => {
    const titulos = props.configCampos.titulos;
    const propriedades = props.configCampos.propriedades;
    return (
        <div>
            <table class="table table-striped">
                <thead>
                    <tr>
                        {
                            titulos.map(x => <th scope="col">{x}</th>)
                        }
                        <th scope="col">Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        props.objetos.map(obj => {
                            return (
                                <tr>
                                    {
                                        propriedades.map(prop => {
                                            return <td>{obj[prop]}</td>
                                        })
                                    }
                                    <td>
                                        <Link to={`/${props.entidade}/${CrudAcao.consultar}/${obj.id}`} class="btn btn-secondary">Consultar</Link>
                                        <Link to={`/${props.entidade}/${CrudAcao.alterar}/${obj.id}`}class="btn btn-warning">Alterar</Link>
                                        <Link to={`/${props.entidade}/${CrudAcao.excluir}/${obj.id}`}class="btn btn-danger">Excluir</Link>
                                    </td>
                                </tr>
                            )
                        })
                    }
                </tbody>
                </table>
        </div>
    );
};

export default CrudLista;