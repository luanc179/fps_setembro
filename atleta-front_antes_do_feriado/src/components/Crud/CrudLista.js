import React from "react";

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