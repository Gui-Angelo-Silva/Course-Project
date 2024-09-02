import React, { useState } from 'react';
import axios from 'axios';
import LogoLogin from "../../assets/logoLogin.png";
import { Eye, EyeSlash } from "@phosphor-icons/react";

const SignUp = ({ onSignInClick }) => {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [showPassword, setShowPassword] = useState(false); // Estado para controlar visibilidade da senha

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await axios.post('https://localhost:7266/api/User/Create', {
                imageUser: 'guigas',
                nameUser: name,
                emailUser: email,
                passwordUser: password,
                phoneUser: '(17)99999-9999',
            });

            if (response.status === 200) {
                alert('Usuário cadastrado com sucesso!');
            }
        } catch (error) {
            setError('Falha ao cadastrar o usuário. Verifique os dados e tente novamente.');
        }
    };

    return (
        <div className='flex flex-col w-3/4 min-h-screen px-12 justify-center'>
            <div className='flex justify-center mb-14'>
                <h1 className='text-4xl text-[#2D2D2D] font-semibold'>Crie a sua conta!</h1>
            </div>
            <div className='flex text-lg'>
                <h2 className=''>
                    Já possui uma conta?
                    <span
                        className="underline hover:cursor-pointer hover:text-[#BD1A37] px-1"
                        onClick={onSignInClick}
                    >
                        Clique aqui para entrar com a sua conta.
                    </span>
                </h2>
            </div>
            {error && <div className='text-red-500 mb-4'>{error}</div>}
            <form onSubmit={handleSubmit} className='flex flex-col gap-y-3 mt-8 text-[#2D2D2D]'>
                <h3 className='text-2xl'>Nome:</h3>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    className='h-[50px] border-[2px] border-[#D9D9D9] rounded-md px-3 text-lg'
                    required
                />
                <h3 className='text-2xl'>Email:</h3>
                <input
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    className='h-[50px] border-[2px] border-[#D9D9D9] rounded-md px-3 text-lg'
                    required
                />
                <h3 className='text-2xl'>Senha:</h3>
                <div className='relative'>
                    <input
                        type={showPassword ? 'text' : 'password'}
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className='h-[50px] border-[2px] border-[#D9D9D9] rounded-md px-3 text-lg pr-10 w-full'
                        required
                    />
                    <button
                        type='button'
                        className='absolute right-2 top-1/2 transform -translate-y-1/2'
                        onClick={() => setShowPassword(!showPassword)}
                    >
                        {showPassword ? <Eye size={30} /> : <EyeSlash size={30}/>}
                    </button>
                </div>
                <button type='submit' className='h-[55px] bg-[#BD1A37] text-2xl text-white mt-[60px]'>
                    Cadastrar
                </button>
            </form>
            <div className='flex w-full justify-center pt-11'>
                <img className='h-[60px] w-[139.35px]' src={LogoLogin} alt="" />
            </div>
        </div>
    );
};

export default SignUp;