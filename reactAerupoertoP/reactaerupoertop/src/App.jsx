import React from 'react';
import Aviones from './pages/Aviones';  // Aseg�rate de que la ruta sea correcta

function App() {
    return (
        <div className="App">
            <h1>Gesti�n de Aviones</h1>
            <Aviones />  {/* Aqu� estamos insertando el componente de aviones */}
        </div>
    );
}

export default App;

