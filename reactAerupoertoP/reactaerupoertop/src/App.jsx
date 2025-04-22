import React from 'react';
import Aviones from './pages/Aviones';  // Asegúrate de que la ruta sea correcta

function App() {
    return (
        <div className="App">
            <h1>Gestión de Aviones</h1>
            <Aviones />  {/* Aquí estamos insertando el componente de aviones */}
        </div>
    );
}

export default App;

