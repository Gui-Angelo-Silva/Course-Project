import React from 'react'
import LayoutPage from '../../components/Layout/LayoutPage'
import CardRestaurant from '../../components/Cards/CardRestaurant'

const MyRestaurant = () => {
    return (
        <LayoutPage>
            <div className='flex w-full justify-center text-2xl mt-5'>
                <h1>{"Nome do Restaurante"}</h1>
            </div>
            <div className='flex w-full'>
                <div className='mt-10 flex justify-evenly w-full'>
                    <CardRestaurant title="Mesas" />
                    <CardRestaurant title="Reservas" />
                </div>
            </div>
        </LayoutPage>
    )
}

export default MyRestaurant