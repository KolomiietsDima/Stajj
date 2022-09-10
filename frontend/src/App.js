import './App.css'
import React from 'react'
import {  Route, Routes } from 'react-router-dom';
import Layout from './components/Layout';
import Body from './components/Body';

function App() {
  return (
    
  
    <Routes>
      <Route path='/' element={<Layout  />}>
        <Route index element={<Body />} /> 
      </Route>
    </Routes>
   
  );
}

export default App;
