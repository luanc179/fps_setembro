import React, {useState, useEffect} from "react";
import { useParams } from "react-router-dom";
import Crud from "../Crud";
import axios from "axios";

const Atleta = () => {

    const {id, acao} = useParams();
    
    const configCampos = {
        titulos: ['Nome', 'Altura'],
        propriedades: ['nome', 'altura']
    }

    const[objetos, setObjetos] = useState([]);
    const [carregando, setCarregando] = useState(true);

    const urlBase = 'http://localhost:5233/api'

    useEffect(() => {
        axios.get(`${urlBase}/atleta`).then(result => {
            setObjetos(result.data);
            setCarregando(false);
        });
    },[carregando]);

    const novoObjeto = () => {
        return { id: '', nome: '', altura: 0, peso: 0 };
    };

    const retornarPorId = (id, retornar) => {
        axios.get(`${urlBase}/atleta/${id}`).then(result => {
            retornar(result.data);
        }).catch(error => {
            retornar(null);
        });
    };

    const inserir = (obj) => {
        axios.post(`${urlBase}/atleta`, obj).then(result => {
        });
    }

    const alterar = (obj) => {
        axios.put(`${urlBase}/atleta/${id}`, obj).then(result => {
        });
    }

    const excluir = (id) => {
        axios.delete(`${urlBase}/atleta/${id}`).then(result => {
        });
    }

    const campos = (somenteLeitura, obj, alterarCampo) => {
        return (<>
            <div className="form-group">
                <label htmlFor="nome">Nome</label>
                <input type="text" readOnly={somenteLeitura} value={obj.nome} onChange={(e) => alterarCampo(e.target.name, e.target.value)} className="form-control" id="nome" name="nome" />
            </div>
            <div className="form-group">
                <label htmlFor="altura">Altura</label>
                <input type="number" readOnly={somenteLeitura} value={obj.altura} onChange={(e) => alterarCampo(e.target.name, e.target.value)} className="form-control" id="altura" name="altura" />
            </div>
            <div className="form-group">
                <label htmlFor="peso">Peso</label>
                <input type="number" readOnly={somenteLeitura} value={obj.peso} onChange={(e) => alterarCampo(e.target.name, e.target.value)} className="form-control" id="peso" name="peso" />
            </div>
        </>);
    }

    if (carregando) {
        return <div>Carregando...</div>;
    }

    return (
        <Crud 
            entidade = "atleta"
            entidadeNomeAmigavel = "Atleta"
            entidadeNomeAmigavelPlural = "Atletas"
            id = {id}
            acao = {acao}
            configCampos = {configCampos}
            objetos={objetos}
            campos={campos}
            novoObjeto={novoObjeto}
            retornarPorId={retornarPorId}
            inserir={inserir}
            alterar={alterar}
            excluir={excluir}
        />
    );
};

export default Atleta;
