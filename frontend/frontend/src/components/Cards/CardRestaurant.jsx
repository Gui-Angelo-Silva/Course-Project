import React from 'react';
import Mesa from "../../assets/Table.png";
import Reserva from "../../assets/imgReserva.png";

const CardRestaurant = ({ title }) => {
    const isMesa = title === "Mesas";
    const imageSrc = isMesa ? Mesa : Reserva;
    const imageAlt = isMesa ? "Manutenção de Mesas" : "Manutenção de Reservas";
    const imageWidth = isMesa ? "w-[160px]" : "w-[220px]";
    const marginBottom = isMesa ? "mb-8" : "mb-20";

    return (
        <div className='h-[500px] w-80 rounded-2xl bg-[#FFC1CC] text-[#BD1A37] shadow-lg cursor-pointer'>
            <div className={`flex justify-center w-full mt-[104px] ${marginBottom}`}>
                <h1 className='text-3xl font-semibold'>{title}</h1>
            </div>
            <div className='flex justify-center w-full'>
                <img className={imageWidth} src={imageSrc} alt={imageAlt} />
            </div>
        </div>
    );
};

export default CardRestaurant;