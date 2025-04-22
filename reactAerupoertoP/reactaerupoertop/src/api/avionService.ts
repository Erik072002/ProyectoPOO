const API_BASE = "/api/Avion";

// Obtener todos los aviones
export const obtenerAviones = async () => {
    try {
        const response = await fetch(API_BASE);
        if (!response.ok) {
            throw new Error('Error al obtener aviones');
        }
        return await response.json();
    } catch (error) {
        console.error("Error en obtenerAviones:", error);
        throw error;
    }
};

// Crear un nuevo avión (sin avionId en el cuerpo)
export const crearAvion = async (avionData) => {
    try {
        const response = await fetch(API_BASE, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Nombre: avionData.Nombre,
                Capacidad: Number(avionData.Capacidad),
            }),
        });

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Error al crear avión');
        }

        return await response.json();
    } catch (error) {
        console.error("Error en crearAvion:", error);
        throw error;
    }
};

// Actualizar un avión (avionId también en el cuerpo, como DevExtreme)
export const actualizarAvion = async (avionId, avionData) => {
    try {
        const response = await fetch(`${API_BASE}/${avionId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                avionId: avionId, // opcional si el backend lo necesita
                Nombre: avionData.Nombre,
                Capacidad: Number(avionData.Capacidad),
            }),
        });


        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Error al actualizar avión');
        }

        return await response.json();
    } catch (error) {
        console.error("Error en actualizarAvion:", error);
        throw error;
    }
};

// Eliminar un avión
export const eliminarAvion = async (avionId) => {
    try {
        const response = await fetch(`${API_BASE}/${avionId}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            throw new Error('Error al eliminar avión');
        }

        return true;
    } catch (error) {
        console.error("Error en eliminarAvion:", error);
        throw error;
    }
};
