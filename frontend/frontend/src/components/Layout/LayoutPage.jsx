import React, { useEffect, useState } from 'react'
import Navbar from './Navbar'
import Sidebar from './Sidebar'
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';

const LayoutPage = ({ children }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const token = Cookies.get('login'); 
    if (token) {
      setIsLoggedIn(true);
    } else {
      setIsLoggedIn(false);
    }
  }, []);

  if (!isLoggedIn) {
    navigate('/');
  }

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
            paddingLeft: '265px',
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