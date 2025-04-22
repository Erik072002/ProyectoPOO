import React, { useEffect, useState } from "react";
import {
    obtenerAviones,
    crearAvion,
    eliminarAvion,
    actualizarAvion,
} from "../api/avionService";

function Aviones() {
    const [aviones, setAviones] = useState([]);
    const [formData, setFormData] = useState({ avionId: "", Nombre: "", Capacidad: "" });
    const [editandoId, setEditandoId] = useState(null);
    const [error, setError] = useState(null);

    const cargarAviones = async () => {
        try {
            const data = await obtenerAviones();
            setAviones(data);
        } catch (err) {
            console.error("Error al cargar los aviones:", err);
            setError("Error al cargar los aviones.");
        }
    };

    useEffect(() => {
        cargarAviones();
    }, []);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);

        const avionData = {
            avionId: formData.avionId ? parseInt(formData.avionId) : null,
            Nombre: formData.Nombre.trim(),
            Capacidad: parseInt(formData.Capacidad),
        };

        // Validación de campos
        if (!avionData.Nombre || isNaN(avionData.Capacidad)) {
            setError("Completa correctamente todos los campos.");
            return;
        }

        try {
            if (!avionData.avionId) {
                // Crear nuevo avión
                const nuevoAvion = await crearAvion(avionData);
                setAviones((prev) => [...prev, nuevoAvion]);
            } else {
                // Actualizar avión existente
                const avionActualizado = await actualizarAvion(avionData.avionId, avionData);
                setAviones((prev) =>
                    prev.map((avion) =>
                        avion.avionId === avionActualizado.avionId ? avionActualizado : avion
                    )
                );
            }

            setFormData({ avionId: "", Nombre: "", Capacidad: "" }); // Resetear formulario
            setEditandoId(null); // Resetear editandoId
        } catch (err) {
            console.error("Error al enviar datos:", err);
            setError("Hubo un error al procesar la solicitud.");
        }
    };

    const handleEditar = (avion) => {
        setFormData({
            avionId: avion.avionId.toString(),
            Nombre: avion.Nombre,
            Capacidad: avion.Capacidad.toString(),
        });
        setError(null);
        setEditandoId(avion.avionId); // Establecer el ID del avión que se está editando
    };

    const handleEliminar = async (id) => {
        try {
            await eliminarAvion(id);
            setAviones((prev) => prev.filter((avion) => avion.avionId !== id));
        } catch (err) {
            console.error("Error al eliminar avión:", err);
            setError("No se pudo eliminar el avión.");
        }
    };

    return (
        <div style={{ padding: "40px", maxWidth: "800px", margin: "auto", fontFamily: "Arial, sans-serif" }}>
            <div style={{ background: "#f4f4f4", padding: "30px", borderRadius: "10px", boxShadow: "0 0 10px rgba(0,0,0,0.1)" }}>
                <h2 style={{ marginBottom: "20px" }}>{editandoId ? "Editar Avión" : "Crear Avión"}</h2>
                <form onSubmit={handleSubmit} style={{ display: "flex", flexDirection: "column", gap: "10px", marginBottom: "20px" }}>
                    {/* Solo habilitar el campo avionId cuando estamos editando */}
                    {editandoId && (
                        <input
                            type="text"
                            name="avionId"
                            value={formData.avionId}
                            onChange={handleChange}
                            placeholder="ID del avión"
                            style={{ padding: "10px", borderRadius: "6px", border: "1px solid #ccc" }}
                            disabled
                        />
                    )}
                    <input
                        type="text"
                        name="Nombre"
                        value={formData.Nombre}
                        onChange={handleChange}
                        placeholder="Nombre del avión"
                        required
                        style={{ padding: "10px", borderRadius: "6px", border: "1px solid #ccc" }}
                    />
                    <input
                        type="number"
                        name="Capacidad"
                        value={formData.Capacidad}
                        onChange={handleChange}
                        placeholder="Capacidad"
                        required
                        style={{ padding: "10px", borderRadius: "6px", border: "1px solid #ccc" }}
                    />
                    <button
                        type="submit"
                        style={{
                            padding: "12px",
                            backgroundColor: "#007bff",
                            color: "#fff",
                            border: "none",
                            borderRadius: "6px",
                            cursor: "pointer",
                            fontWeight: "bold"
                        }}
                    >
                        {editandoId ? "Actualizar" : "Crear"}
                    </button>
                </form>

                {error && <p style={{ color: "red", marginBottom: "10px" }}>{error}</p>}

                <h3 style={{ marginTop: "20px" }}>Lista de Aviones</h3>
                <table style={{ width: "100%", borderCollapse: "collapse", marginTop: "10px" }}>
                    <thead style={{ backgroundColor: "#007bff", color: "white" }}>
                        <tr>
                            <th style={{ padding: "10px", textAlign: "left" }}>ID</th>
                            <th style={{ padding: "10px", textAlign: "left" }}>Nombre</th>
                            <th style={{ padding: "10px", textAlign: "left" }}>Capacidad</th>
                            <th style={{ padding: "10px", textAlign: "left" }}>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        {aviones.map((avion) => (
                            <tr key={avion.avionId} style={{ borderBottom: "1px solid #ddd" }}>
                                <td style={{ padding: "10px" }}>{avion.avionId}</td>
                                <td style={{ padding: "10px" }}>{avion.Nombre}</td>
                                <td style={{ padding: "10px" }}>{avion.Capacidad}</td>
                                <td style={{ padding: "10px" }}>
                                    <button
                                        onClick={() => handleEditar(avion)}
                                        style={{
                                            padding: "6px 12px",
                                            backgroundColor: "#ffc107",
                                            border: "none",
                                            borderRadius: "4px",
                                            marginRight: "10px",
                                            cursor: "pointer"
                                        }}
                                    >
                                        Editar
                                    </button>
                                    <button
                                        onClick={() => handleEliminar(avion.avionId)}
                                        style={{
                                            padding: "6px 12px",
                                            backgroundColor: "#dc3545",
                                            color: "white",
                                            border: "none",
                                            borderRadius: "4px",
                                            cursor: "pointer"
                                        }}
                                    >
                                        Eliminar
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default Aviones;
