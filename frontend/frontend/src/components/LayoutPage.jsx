import React from 'react'
import Navbar from './Navbar'
import Sidebar from './Sidebar'

const LayoutPage = ({ children }) => {
  return (
    <div className="flex flex-col min-h-screen overflow-hidden">
      <div className="flex fixed w-full top-0 z-10" style={{ minHeight: '50px' }}>
        {/*  Aqui irá ficar o Navbar  */}
        <Navbar />
      </div>
      <div className="flex flex-row flex-grow mt-[56px] sm:mt-[64px]">
        {/* SideBarAdm fixa na lateral esquerda */}
        <div className="flex fixed h-full top-[56px] sm:top-[64px] z-10">
          <Sidebar />
        </div>

        {/* Conteúdo principal adaptável */}
        <div
          className="flex-grow overflow-y-auto scrollable-container"
          style={{
            paddingLeft: 'calc(60px + 15px)',  // Espaçamento quando SideBarAdm está compacto
            paddingTop: '15px',
            paddingRight: '15px',
            paddingBottom: '15px',
            maxHeight: 'calc(100vh - 64px)',
          }}
        >
          <div className=''>
            {children}
          </div>
        </div>
      </div>
    </div>
  )
}

export default LayoutPage