use Staj

INSERT INTO Users (
    Email,
    UserId,
	FirstName,
	[LastName],
	[Password],
	[EmailConfirmed],
	[PhoneNumberConfirmed],
	[TwoFactorEnabled],
	[LockoutEnabled],
	[AccessFailedCount]
)
VALUES
		('Kolomietsdima774@gmail.com',
		'2Z5W/pmgjkL8kCv/VdnWw',
		'Dmytro',
		'Kolomiiets',
		'$2a$11$DhASsVaMCaKde0RXlAqHtOqDCaiXRYxsRme5FZfJQgbvhiIa5aU7W',
		0,
		0,
		0,
		0,
		0
	),
    (
        'VladDemchisin@gmaill.com',
        'ytrFsbk2UEbxHO5wMBow',
		'Vlad',
		'Demchishin',
		'V!!!111v',
		0,
		0,
		0,
		0,
		0
		
    ),
    (
        'AnnaMaslak@gmaill.com',
        'Njfssbk2fEbxHO5wMBow',
		'Anna',
		'Maslak',
		'A!!!111a',
		0,
		0,
		0,
		0,
		0

    ),
    (
        'LehaAleynikov@gmaill.com',
        'iUnfsb42UEbxHO5wMBow',
		'Leha',
		'Aleynikov',
		'L!!!111l',
		0,
		0,
		0,
		0,
		0

    )
	
   

INSERT INTO Chat (
    ChatName,
    [Type]
)
VALUES
    (
        'Room1',
        'Private'
    ),
    (
        'Room2',
        'Private'

    ),
    (
        'Room3',
        'Private'

    ),
	(
        'Room4',
        'Public'

    );




	INSERT INTO Participants (
    UserId,
    ChatId
)
VALUES
    (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '1'
    ),
    (
        'ytrFsbk2UEbxHO5wMBow',
        '1'

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2'
    ),
    (
        'Njfssbk2fEbxHO5wMBow',
        '2'

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '3'
    ),
	(
        'iUnfsb42UEbxHO5wMBow',
        '3'

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '4'
    ),
	(
        'iUnfsb42UEbxHO5wMBow',
        '4'
    ),
	(
        'Njfssbk2fEbxHO5wMBow',
        '4'
    ),
	(
        'ytrFsbk2UEbxHO5wMBow',
        '4'
    );






	INSERT INTO [Message] (
    UserId,
    ChatId,
	Body,
	DataCreated
)
VALUES
    (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '1',
		'Hi, Vlad! Happy birthday, honey!',
          GETDATE()
		
    ),
    (
        'ytrFsbk2UEbxHO5wMBow',
        '1',
		'Oh, thank you, Dima! You’re always the first one to call me on my birthday! It’s so nice you remember this day',
          DATEADD(second,2,GETDATE())

    ),
	(
		'2Z5W/pmgjkL8kCv/VdnWw',
        '1',
		'And on this special day I’m wishing you everything your heart desires. May all your dreams come true and hope the sun shines on you and the wind blows at your back.',
          DATEADD(second,4,GETDATE())
	),
	(
        'ytrFsbk2UEbxHO5wMBow',
        '1',
		'Thank you, darling. Could you come over to my house tonight? I’m having some friends over to blow the candles on the birthday cake.',
          DATEADD(second,8,GETDATE())

    ),
	(
		'2Z5W/pmgjkL8kCv/VdnWw',
        '1',
		'Oh, I’d love to, Vlad! Thanks for the invitation.',
          DATEADD(second,10,GETDATE())
	),
	(
        'ytrFsbk2UEbxHO5wMBow',
        '1',
		'Cool! Ok then. See you later.',

          DATEADD(second,12,GETDATE())

    );


	INSERT INTO [Message] (
    UserId,
    ChatId,
	Body,
	DataCreated
)
VALUES
    (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '4',
		'Dobryi Den Everybody',
          GETDATE()
		
    ),
    (
        'ytrFsbk2UEbxHO5wMBow',
        '4',
		'Hi,Dima',
          DATEADD(second,2,GETDATE())

    ),
	(
		'Njfssbk2fEbxHO5wMBow',
        '4',
		'Hello,how is it going?',
          DATEADD(second,4,GETDATE())
	),
	(
        'iUnfsb42UEbxHO5wMBow',
        '4',
		'Dima as always',
          DATEADD(second,8,GETDATE())

    ),
	(
		'2Z5W/pmgjkL8kCv/VdnWw',
        '4',
		'Don`t be boring',
          DATEADD(second,10,GETDATE())
	),
	(
        'ytrFsbk2UEbxHO5wMBow',
        '4',
		'You are so funny',

          DATEADD(second,12,GETDATE())

    );



	INSERT INTO [Message] (
    UserId,
    ChatId,
	Body,
	DataCreated
)
VALUES
    (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          GETDATE()

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,2,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
         DATEADD(second,3,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,4,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,5,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,6,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
         DATEADD(second,7,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,8,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,9,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,10,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,11,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,12,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,13,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,14,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,15,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,16,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,17,GETDATE())

    ),
	(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,18,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,19,GETDATE())

    ),
(
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,20,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,21,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,22,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,23,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,24,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,25,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,26,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,27,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,28,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,29,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,30,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,31,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,32,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,33,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,34,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,35,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,36,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,37,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,38,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,39,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,40,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,41,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
          DATEADD(second,42,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,43,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,44,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,45,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,46,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'Message',
          DATEADD(second,47,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'Message',
         DATEADD(second,48,GETDATE())
		
    ),
	 (
        'Njfssbk2fEbxHO5wMBow',
        '2',
		'There are more than 20 messages in this chat',
          DATEADD(second,49,GETDATE())

    ),
	 (
        '2Z5W/pmgjkL8kCv/VdnWw',
        '2',
		'There are more than 20 messages in this chat',
         DATEADD(second,50,GETDATE())
		
    );



	Insert into MessageReply 
	Values (7,10);

	Insert into MessageReply 
	Values (10,11);

	Insert into MessageReply 
	Values (4,5);




