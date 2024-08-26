import React from 'react'

const Sidebar = () => {
  return (
    <div className='fixed flex-col w-[250px] h-full border-r-2 border-[#BD1A37]'>
      <div className='flex flex-col text-lg text-[#BD1A37]'>
        <button className='h-12 hover:bg-[#dd637a] hover:text-white border-b-2 border-solid border-[#c4c4c4]'>Página Inicial</button>
        <button className='h-12 hover:bg-[#dd637a] hover:text-white border-b-2 border-solid border-[#c4c4c4]'>Meu Restaurante</button>
      </div>
    </div>
  )
}

export default Sidebar