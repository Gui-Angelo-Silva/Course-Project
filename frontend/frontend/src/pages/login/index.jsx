import React, { useState } from 'react';
import ImageLogin from "../../assets/imageLogin.png";
import SignIn from "../../components/Login/SignIn"
import SignUp from '../../components/Login/SignUp'; 

const Login = () => {
    const [showSignIn, setShowSignIn] = useState(true);

    return (
        <div className="flex flex-row min-h-screen overflow-hidden">
            <div className='flex w-1/2 border-r-[6px] border-[#D6915B] bg-cover' style={{
                backgroundImage: `url(${ImageLogin})`
            }}>
            </div>
            <div className='flex w-1/2 border-l-[10px] border-[#BD1A37] justify-center items-center'>
                {showSignIn ? (
                    <SignIn onSignUpClick={() => setShowSignIn(false)} />
                ) : (
                    <SignUp onSignInClick={() => setShowSignIn(true)} />
                )}
            </div>
        </div>
    );
}

export default Login;