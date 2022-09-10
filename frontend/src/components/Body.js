import { useState, useEffect } from 'react';
import React from 'react';
import './Body.css'
import Avatar from '@mui/material/Avatar';
import Stack from '@mui/material/Stack';
import nodata1 from '../Photos/preview.png'
import centre from '../Photos/centre.png'
import group from '../Photos/group.png'
import EventEmitter from '../utils/EventEmitter';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import TextareaAutosize from '@mui/material/TextareaAutosize';
import TelegramIcon from '@mui/icons-material/Telegram';
import DeleteIcon from '@mui/icons-material/Delete';
import ReplyIcon from '@mui/icons-material/Reply';
import { notification, Popconfirm } from 'antd';
import 'antd/dist/antd.css';
import Skeleton from '@mui/material/Skeleton';
import ClearIcon from '@mui/icons-material/Clear';



export default function Body(props) {
    const [PrivateChatData, setPrivateChatData] = useState([]);
    const [PublicChatData, setPublicChatData] = useState([]);
    const [ChatMessages, setChatMessages] = useState([]);
    const [UserId, setUserId] = useState('');
    const [Auth, setAuth] = useState(props.Auth)
    const [ChatUsers, setChatUsers] = useState([]);
    const [MessageToSend, setMessageToSend] = useState({ body: '' });
    const [CurrentChat, setCurrentChat] = useState();
    const [Chatloading, setChatloading] = useState(false);
    const [MessageToReply, setMessageToReply] = useState({ body: '' });
    const [IsChatClicked, setIsChatClicked] = useState(false);
    const [matches, setMatches] = useState(
        window.matchMedia("(min-width: 400px)").matches
    )

    const openNotification = (placement) => {
        const args = {
            message: `Info `,
            description:
                'You can choose the chat where to send the message',
            placement,
            duration: 5,
        };
        notification.open(args);
    };


    useEffect(() => {

        window
            .matchMedia("(min-width: 400px)")
            .addEventListener('change', e => setMatches(e.matches));

        setChatloading(true);
        setChatloading(props.Chatloading)
        setPublicChatData(props.PublicChatData)
        setPrivateChatData(props.PrivateChatData)
        setChatMessages(props.ChatMessages)
        setUserId(props.UserId)
        setAuth(props.Auth)
        setChatUsers(props.ChatUsers);

        const onNewLog = (eventData) => {
            setIsChatClicked(false);
            setAuth(eventData)
            setPrivateChatData(eventData)
            setPublicChatData(eventData)
            setChatMessages(eventData)
            setChatUsers(eventData)
        }
        const listener = EventEmitter.addListener('NewLog', onNewLog)

        return () => {
            listener.remove();
        }
    }, [props]);

    const GetChatMessages = (chatId) => {
        setMessageToSend({ ...MessageToSend, body: '' })
        props.GetChatMessages(chatId);
        setCurrentChat(chatId);
    }
    const PostMessage = () => {
        setMessageToSend({ ...MessageToSend, body: '' })
        if (MessageToReply.message) {
            props.PostMessage(MessageToSend.body, CurrentChat, MessageToReply.message.id)
        }
        else {
            props.PostMessage(MessageToSend.body, CurrentChat)
        }

    }


    const ReplyMessage = (message) => {
        openNotification('top')
        setMessageToReply({ ...MessageToReply, message })

    }
    const cancelReply = () => {

        setMessageToReply({ ...MessageToReply, message: null })
    }
    const ChatClicked = (chatId) => {

        setIsChatClicked(true);
        GetChatMessages(chatId)

    }

    return (
        <div>
            <div className='BodyRow'>



                <div className='BodyLeftCol' >
                    {(Auth ? <div> <div className='yourchats' >Your Chats  </div>{Chatloading ? <Skeleton animation="wave" /> : null} </div> : <div className='PlsLog'>Please, Log In </div>)}
                    {(PrivateChatData.length ?
                        PrivateChatData.map(data => (




                            <div key={data.chatId} className='usersChats'>
                                <Stack direction="row" spacing={1} >
                                    {matches && (<Avatar sx={{ bgcolor: '#8787e9' }} >{data.firstName.substring(0, 1)}</Avatar>)}
                                    {!matches && (<Avatar sx={{ bgcolor: '#8787e9', width: 23, height: 23, fontSize: 10 }} >{data.firstName.substring(0, 1)}</Avatar>)}

                                    <span className='AvatarName' onClick={() => ChatClicked(data.chatId)}>{data.firstName + ' '}{data.lastName}</span>
                                </Stack>
                            </div>
                        )) : <div className='img'><img alt="nodata1" style={{ display: 'block' }} width={300} height={300} src={nodata1} /></div>

                    )}
                    {(PublicChatData.length ?
                        PublicChatData.map(data => (<div key={data.id} className='usersChats'>
                            <Stack direction="row" spacing={1} >
                                {matches && (<Avatar src={group} sx={{ bgcolor: '#8787e9' }} ></Avatar>)}
                                {!matches && (<Avatar src={group} sx={{ bgcolor: '#8787e9', width: 23, height: 23, fontSize: 10 }} ></Avatar>)}
                                <span className='AvatarName' onClick={() => ChatClicked(data.id)}>{data.name}</span>

                            </Stack>
                        </div>)) : null)}


                </div>



                <div className={ChatMessages.length ? 'BodyCentreCol' : 'BodyCentreColMain'}>

                    {(ChatMessages.length ?
                        ChatMessages.sort((a, b) => {
                            return new Date(b.dataCreated) - new Date(a.dataCreated);
                        }).map(data => (
                            <div key={data.id}>
                                {data.deletedUser !== UserId ?
                                    <div className="container">

                                        {data.fFirstName ?
                                            UserId === data.userId ?
                                                <Stack direction="row" spacing={2} className="message-ReplyR" >
                                                    <TelegramIcon style={{ fontSize: 12 }}></TelegramIcon>
                                                    <span style={{ fontSize: 10 }}>{data.fFirstName + ' :'}</span>
                                                    <div > {data.fbody.substring(0, 10) + '...'}    </div>
                                                </Stack> : 
                                                <Stack direction="row" spacing={2} className="message-reply" >
                                                    <TelegramIcon style={{ fontSize: 12 }}></TelegramIcon>
                                                    <span style={{ fontSize: 10 }}>{data.fFirstName + ' :'}</span>
                                                    <div > {data.fbody.substring(0, 10) + '...'}    </div>
                                                </Stack>
                                                 : null}

                                        <Stack direction="row" spacing={1} >
                                            {UserId === data.userId ?
                                                <>
                                                    <span className="UserNick">Me  </span>
                                                </>
                                                : <>
                                                    <Avatar className='message-req' sx={{ bgcolor: '#8787e9', width: 20, height: 20, fontSize: 15 }} >{data.firstName.substring(0, 1)}</Avatar><span className='UserNick'>{data.firstName + ' ' + data.lastName}</span></>}
                                        </Stack>
                                        <div className={UserId === data.userId ? 'message-orange' : 'message-blue'}>
                                            <p className="message-content">{data.body}</p>


                                            <div className="message-timestamp-left">{data.dataCreated.replace('T', '').substring(10, 18)}</div>


                                            {UserId === data.userId ?
                                                <>

                                                    <span className="message-timestamp-left">{' / ' + data.dataCreated.replace('T', '').substring(2, 10)}</span>
                                                    <Popconfirm
                                                        title="Delete for all Users?"
                                                        onConfirm={() => { props.DeleteMessage(data.id, data.chatId) }}
                                                        onCancel={() => { props.DeleteMessageOnlyForUser(data.id, data.chatId) }}
                                                        okText="Yes"
                                                        cancelText="No"
                                                    >
                                                        <DeleteIcon className='deleteIcon' sx={{ cursor: 'pointer', width: 12, height: 12, top: 4, position: 'relative' }}  ></DeleteIcon>
                                                    </Popconfirm>


                                                </>
                                                :
                                                <><span className="message-timestamp">{data.dataCreated.replace('T', '').substring(2, 10)}</span> <Stack className="message-timestamp-right" direction="row" spacing={1} ><ReplyIcon onClick={() => { ReplyMessage({ userId: data.userId, body: data.body, id: data.id, dataCreated: data.dataCreated, firstName: data.firstName }) }} sx={{ cursor: 'pointer', width: 14, height: 14, top: 4, position: 'relative' }}  ></ReplyIcon> </Stack></>}




                                        </div>

                                    </div> : null}
                            </div>


                        )) : <div className='img'><img alt='centre' style={{ display: 'block' }} height={350} src={centre} /></div>)}
                    {(ChatMessages.length >= 20 ? <span className='FetchData' onClick={function () {
                        props.FetchHandler(ChatMessages[0].chatId)
                    }}>FetchData</span> : null)}
                    {(Auth ? null : <div className='PlsLog'>Please, Log In </div>)}

                </div>


                <div className='BodyRightCol' >
                    {(Auth && ChatUsers.length ? <div className='yourchats' >Chat with: </div> : <div className='DataforLog'>Data for Login: kolomietsdima774@gmail.com  password: F111!!!f </div>)}
                    {(ChatUsers.length ? ChatUsers.map(data => (

                        <div key={data.firstName + ' ' + data.lastName}>
                            <Stack className='RightAvatar' direction="column" >
                                <AccountCircleIcon sx={{ width: 50, height: 50, fontSize: 30 }} >{data.firstName.substring(0, 1)}</AccountCircleIcon>
                                <div className='RightNickNames' >{data.firstName + ' '}{data.lastName}</div>


                            </Stack>
                        </div>)) : null)}



                </div>



            </div>
            {(IsChatClicked ?
                <Stack className='RightAvatar' direction="row" spacing={2} >
                    {MessageToReply.message ? <Stack direction="row" spacing={2} className="message-Rres" >
                        <TelegramIcon style={{ fontSize: 12 }}></TelegramIcon>
                        <span style={{ fontSize: 10 }}>{MessageToReply.message.firstName + ' :'}</span>
                        <div > {MessageToReply.message.body.substring(0, 10) + '...'}    </div>
                        <ClearIcon onClick={cancelReply} style={{ fontSize: 12, color: 'red', cursor: 'pointer' }} ></ClearIcon>
                    </Stack> : null}
                    {matches && (<><TextareaAutosize
                        className='textArea'
                        aria-label="empty textarea"
                        placeholder="Write..."
                        onChange={e => setMessageToSend({ ...MessageToSend, body: e.target.value })} value={MessageToSend.body}
                        style={{ marginLeft: 50, width: 700, height: 42, maxHeight: 200, maxWidth: 900, minHeight: 40, minWidth: 700 }}
                    />
                        <button onClick={PostMessage} className='butSend'><TelegramIcon sx={{ width: 25, height: 25 }}></TelegramIcon></button></>)}
                    {!matches && (<><TextareaAutosize
                        className='textArea'
                        aria-label="empty textarea"
                        placeholder="Write..."
                        onChange={e => setMessageToSend({ ...MessageToSend, body: e.target.value })} value={MessageToSend.body}
                        style={{ marginLeft: 50, width: 150, height: 32, maxHeight: 100, maxWidth: 200, minHeight: 30, minWidth: 150 }}
                    /><button onClick={PostMessage} className='butSend'><TelegramIcon sx={{ width: 15, height: 15 }}></TelegramIcon></button></>)}

                </Stack> : null)}



        </div>
    )

}