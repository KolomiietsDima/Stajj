import { useState, useEffect } from 'react';
import React from 'react';
import { Modal, TextField, Box, Button} from '@mui/material';
import InputAdornment from '@mui/material/InputAdornment';
import { AccountCircle } from '@mui/icons-material';
import './Header.css'
import EventEmitter from '../utils/EventEmitter';
import { Spin } from 'antd';
import 'antd/dist/antd.css';

export default function Header(props) {
    const [open, setOpen] = React.useState(props.open);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    const [User, setUser] = useState({ Email: '', Password: '', RememberMe: '', PasswordConfirm: '' });
    const [Auth, setAuth] = useState(props.Auth)
    const [, setUserId] = useState(props.UserId);
    const [loading, setLoading] = useState(false);

    const validateEmail = (email) => {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    useEffect(() => {
        setLoading(props.loading)
        setOpen(false);
        setAuth(props.Auth);
        setUserId(props.UserId)
    }, [props]);



    const submitHandlerL = e => {

        if (!validateEmail(User.Email)) {

        }
        let str = User.Password;
        if (str.length < 6) {

        }
        else if (str.length > 17) {

        }
        else {

            let user = { Email: User.Email, Password: User.Password }
            setLoading(true);
            props.Login(user);
        }

    }

    const Logout = () => {
        setAuth(false);
        localStorage.removeItem('token');
        EventEmitter.emit('NewLog', false)





    }





    return (
        <div className='row'>


            
            <div className='Leftcol' >
                Welcome
            </div>
          


            <div className='col'>

            </div>

            {Auth ? <div className='Rightcol' onClick={Logout} >

                Dmytro Kolomiiets

            </div> : <div className='Rightcol' onClick={handleOpen} >

                Log in

            </div>}
            <Spin size="large"  spinning={loading}>
            
                <Modal
                    open={open}
                    onClose={handleClose}
                >
                    <Box sx={{
                        position: 'absolute',
                        top: '50%',
                        left: '50%',
                        transform: 'translate(-50%, -50%)',
                        width: 360,
                        height: 300,
                        bgcolor: '#ccc8c8',
                        color: 'white',
                        border: '2px solid #000',
                        boxShadow: 24,
                        p: 4,

                    }} >
                        <div>
                            <TextField sx={{ marginTop: 4, marginLeft: 4, width: 245 }} onChange={e => setUser({ ...User, Email: e.target.value })} value={User.Email} id="input-with-icon-textfield" label="Log in" InputProps={{ startAdornment: (<InputAdornment position="start"><AccountCircle /></InputAdornment>), }} variant="standard" />
                            <TextField sx={{ marginTop: 4, marginLeft: 4, width: 245 }} onChange={e => setUser({ ...User, Password: e.target.value })} value={User.Password} id="standard-adornment-password" type={'password'} label="Password" variant="standard" />
                        </div>
                        <div>
                            <Button sx={{ marginTop: 4, marginLeft: 4, backgroundColor: '#8b95cc' }} onClick={submitHandlerL} variant="contained">Submit</Button>

                        </div>
                    </Box>

                </Modal>
                </Spin>

        </div>
    )

}