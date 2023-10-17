import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Atleta from "./components/Atleta";
import Treinador from "./components/Treinador";

const Rotas = () => {
    return (<BrowserRouter>
    <Routes>
      <Route path='/' element={<Atleta />} />
      <Route path='atleta' element={<Atleta />}>
        <Route path=':acao' element={<Atleta />} />
        <Route path=':acao/:id' element={<Atleta />} />
      </Route>
      <Route path='treinador' element={<Treinador />}>
        <Route path=':acao' element={<Treinador />} />
        <Route path=':acao/:id' element={<Treinador />} />
      </Route>
    </Routes>
  </BrowserRouter>);
};

export default Rotas;
