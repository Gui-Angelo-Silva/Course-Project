import { Desktop, ForkKnife } from '@phosphor-icons/react'
import React from 'react'
import { Link } from 'react-router-dom'

const Sidebar = () => {
  return (
    <div className='fixed flex-col w-[250px] h-full border-r-[1px] border-[#BD1A37]'>
      <div className='flex flex-col text-lg text-[#BD1A37]'>
        <Link to="/inicio">
          <div className='h-12 flex items-center pl-6 gap-x-4 hover:bg-[#dd637a] hover:text-white border-b-2 border-solid border-[#E2B7BF] cursor-pointer'>
            <Desktop size={32} />
            <h1>Página Inicial</h1>
          </div>
        </Link>
        <Link to="/restaurante">
          <div className='h-12 flex items-center pl-6 gap-x-4 hover:bg-[#dd637a] hover:text-white border-b-2 border-solid border-[#E2B7BF] cursor-pointer'>
            <ForkKnife size={30} />
            <h1>Meu Restaurante</h1>
          </div>
        </Link>
      </div>
    </div>
  )
}

export default Sidebar