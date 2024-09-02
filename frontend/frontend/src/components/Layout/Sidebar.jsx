import React from 'react'

const Sidebar = () => {
  return (
    <div className='fixed flex-col w-[250px] h-full border-r-[1px] border-[#BD1A37]'>
      <div className='flex flex-col text-lg text-[#BD1A37]'>
        <button className='h-12 hover:bg-[#dd637a] hover:text-white border-b-2 border-solid border-[#E2B7BF]'>Página Inicial</button>
        <button className='h-12 hover:bg-[#dd637a] hover:text-white border-b-2 border-solid border-[#E2B7BF]'>Meu Restaurante</button>
      </div>
    </div>
  )
}

export default Sidebar