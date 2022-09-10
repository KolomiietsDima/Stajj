import { useState, useEffect } from 'react';
import React from 'react';
import Header from './Header';
import Body from './Body';
import Footer from './Footer';
import './Layout.css'
import axios from 'axios';
import EventEmitter from '../utils/EventEmitter';
import { message } from 'antd';


export const AuthHeader = () => {

    return { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } }

}




export default function Layout(props) {
    const [open, setOpen] = React.useState(false);
    const [UserId, setUserId] = useState();
    const [Auth, setAuth] = useState(localStorage.getItem('token'))
    const [PublicChatData, setPublicChatData] = useState([]);
    const [PrivateChatData, setPrivateChatData] = useState([]);
    const [ChatMessages, setChatMessages] = useState([]);
    const [ChatUsers, setChatUsers] = useState([]);
    const [CurrentPage, setCurrentPage] = useState(1);
    const [loading, setLoading] = useState(false);
    const [Chatloading, setChatloading] = useState(false);

    const Logout = () => {
        setAuth(false);
        localStorage.removeItem('token');
        EventEmitter.emit('NewLog',false)

    }

    

    useEffect(() => {
        (

            async () => {

                axios.get('Chat/GetAllPrivateUsersChats', AuthHeader())
                    .then((response) => {
                       
                        setPrivateChatData(response.data.$values);

                        axios.get('Chat/GetAllPublicUsersChats', AuthHeader())
                            .then((response) => {

                                
                                setPublicChatData(response.data.$values);
                                setChatloading(false);
                            })
                            .catch(function (error) {
                                if (error.response) {
                                    if (error.response.status === 401) {

                                        Logout()
                                    } else if (error.request) {
                                        message.error('Ooops something gone wrong ');
                                    } else {
                                        message.error('Ooops something gone wrong ');
                                    }
                                }
                            })
                        axios.get('api/Auth/GetMyId', AuthHeader())
                            .then((response) => {
                                
                                setUserId(response.data);
                            })
                            .catch(function (error) {
                                if (error.response) {
                                    if (error.response.status === 401) {

                                        Logout()
                                    } else if (error.request) {
                                        message.error('Ooops something gone wrong ');
                                    } else {
                                        message.error('Ooops something gone wrong ');
                                    }
                                }
                            })
                            

                    })
                    .catch(function (error) {
                        if (error.response) {
                            if (error.response.status === 401) {

                                Logout()
                            } else if (error.request) {
                                message.error('Ooops something gone wrong ');
                            } else {
                                message.error('Ooops something gone wrong ');
                            }
                        }
                    })

                    const onNewLog = (eventData) => {
                        
                        setAuth(eventData)
                        
                    }
                    const listener = EventEmitter.addListener('NewLog', onNewLog)
            
                    return () => {
                        listener.remove();
                    }

            })();
    }, [Auth]);






    const Login = user => {

        axios.post('api/Auth/Login', { Email: user.Email, Password: user.Password })
            .then((response) => {
                let Response = response.data.status;

                localStorage.setItem('token', response.data.message);
                if (Response === 'Success') {

                    setLoading(false);
                    setOpen(false);
                    setAuth(true);
                    setUserId(response.data.$values.id)
                    message.success('Welcome');
                }
                else {


                }

            })
            .catch(function (error) {

                if (error.response) {
                    if (error.response.status === 401) {
                        Logout()
                    } else if (error.request) {
                        message.error('Ooops something gone wrong,check if the data is entered correctly  ');
                       
                    } else {
                        message.error('Ooops something gone wrong,check if the data is entered correctly ');
                       
                    }
                }
            })



    }

    const FetchHandler = (chatId) => {

        GetNewChatMessages(chatId, CurrentPage);
    }

    const GetNewChatMessages = (chatId, PageNumber = 1) => {

        axios.get(`Message/GetChatMessages?chatId=${chatId}&PageNumber=${PageNumber}&PageSize=20`, AuthHeader())

            .then((response) => {
               

                
                setChatMessages([...ChatMessages, ...response.data.data.$values]);
                setCurrentPage(CurrentPage + 1)
                axios.get(`Chat/GetUsersFromChat?chatId=${chatId}`, AuthHeader())
                    .then((response) => {
                        setChatUsers(response.data.$values)

                    })
                    .catch(function (error) {

                        if (error.response) {
                            if (error.response.status === 401) {
                                Logout()
                            } else if (error.request) {
                                message.error('Ooops something gone wrong ');
                            } else {
                                message.error('Ooops something gone wrong ');
                            }
                        }
                    })

            })
            .catch(function (error) {

                if (error.response) {
                    if (error.response.status === 401) {
                        Logout()
                    } else if (error.request) {
                        message.error('Ooops something gone wrong ');
                    } else {
                        message.error('Ooops something gone wrong ');
                    }
                }
            })
    }
    const GetChatMessages = (chatId, PageNumber = 1) => {

        axios.get(`Message/GetChatMessages?chatId=${chatId}&PageNumber=${PageNumber}&PageSize=20`, AuthHeader())

            .then((response) => {
                
                
                
                setChatMessages(response.data.data.$values);
                setCurrentPage(2)
                axios.get(`Chat/GetUsersFromChat?chatId=${chatId}`, AuthHeader())
                    .then((response) => {
                        setChatUsers(response.data.$values)

                    })
                    .catch(function (error) {

                        if (error.response) {
                            if (error.response.status === 401) {
                                Logout()
                            } else if (error.request) {
                                message.error('Ooops something gone wrong ');
                            } else {
                                message.error('Ooops something gone wrong ');
                            }
                        }
                    })

            })
            .catch(function (error) {

                if (error.response) {
                    if (error.response.status === 401) {
                        Logout()
                    } else if (error.request) {
                        message.error('Ooops something gone wrong ');
                    } else {
                        message.error('Ooops something gone wrong ');
                    }
                }
            })



    }
    const PostMessage = (MessageToSend, CurrentChatId,forwardId = 0) => {
       
        axios.post(`Message/CreateMessage?Id_MessageForward=${forwardId}`,{ body: MessageToSend,chatId:CurrentChatId },   AuthHeader())

            .then((response) => {
                GetChatMessages(CurrentChatId);

            })
            .catch(function (error) {

                if (error.response) {
                    if (error.response.status === 401) {
                        Logout()
                    } else if (error.request) {
                        message.error('Ooops something gone wrong ');
                    } else {
                        message.error('Ooops something gone wrong ');
                    }
                }
            })
    }
    const DeleteMessage = (MessageId,CurrentChatId) => {
       
        axios.delete(`Message/DeleteMessage?Id=${MessageId}`,   AuthHeader())

            .then((response) => {
                GetChatMessages(CurrentChatId);

            })
            .catch(function (error) {

                if (error.response) {
                    if (error.response.status === 401) {
                        Logout()
                    } else if (error.request) {
                        message.error('Ooops something gone wrong ');
                    } else {
                        message.error('Ooops something gone wrong ');
                    }
                }
            })
    }
    const DeleteMessageOnlyForUser = (MessageId,CurrentChatId) => {
      
        axios.put('Message/DeleteMessageOnlyForUser',{ Id: MessageId },AuthHeader())

            .then((response) => {
                GetChatMessages(CurrentChatId);

            })
            .catch(function (error) {

                if (error.response) {
                    if (error.response.status === 401) {
                        Logout()
                    } else if (error.request) {
                        message.error('Ooops something gone wrong ');
                    } else {
                        message.error('Ooops something gone wrong ');
                    }
                }
            })
    }


  


    return (
        <div className='layout'>
            <Header loading={loading} Login={Login} Auth={Auth} UserId={UserId} open={open} />
            <Body Chatloading={Chatloading} DeleteMessageOnlyForUser={DeleteMessageOnlyForUser}  DeleteMessage={DeleteMessage}  PostMessage ={PostMessage} FetchHandler={FetchHandler} GetChatMessages={GetChatMessages} PublicChatData={PublicChatData} PrivateChatData={PrivateChatData} Auth={Auth} ChatMessages={ChatMessages} UserId={UserId} ChatUsers={ChatUsers} />

            <Footer />
        </div>
    )
}