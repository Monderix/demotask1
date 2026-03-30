--
-- PostgreSQL database dump
--

\restrict j6X5S7bj0wpyoSjYAbVVnnpCaqE99vbRBqg9at3pXiWCow3KgDaElB8XX88tEu7

-- Dumped from database version 17.6
-- Dumped by pg_dump version 17.6

-- Started on 2026-03-30 21:18:14

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 25022)
-- Name: category; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.category (
    id integer NOT NULL,
    category_pk character varying(155)
);


ALTER TABLE public.category OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 25025)
-- Name: category_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.category_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.category_id_seq OWNER TO postgres;

--
-- TOC entry 4995 (class 0 OID 0)
-- Dependencies: 218
-- Name: category_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.category_id_seq OWNED BY public.category.id;


--
-- TOC entry 219 (class 1259 OID 25026)
-- Name: claim_points_addresses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.claim_points_addresses (
    id integer NOT NULL,
    address character varying
);


ALTER TABLE public.claim_points_addresses OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 25031)
-- Name: name_tovar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.name_tovar (
    id integer NOT NULL,
    name_tovar_pk character varying(155)
);


ALTER TABLE public.name_tovar OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 25034)
-- Name: name_tovar_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.name_tovar_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.name_tovar_id_seq OWNER TO postgres;

--
-- TOC entry 4996 (class 0 OID 0)
-- Dependencies: 221
-- Name: name_tovar_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.name_tovar_id_seq OWNED BY public.name_tovar.id;


--
-- TOC entry 222 (class 1259 OID 25035)
-- Name: order_product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.order_product (
    id integer NOT NULL,
    order_id integer,
    article_fk character varying(55),
    quantity integer
);


ALTER TABLE public.order_product OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 25038)
-- Name: order_product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.order_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.order_product_id_seq OWNER TO postgres;

--
-- TOC entry 4997 (class 0 OID 0)
-- Dependencies: 223
-- Name: order_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.order_product_id_seq OWNED BY public.order_product.id;


--
-- TOC entry 224 (class 1259 OID 25039)
-- Name: orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.orders (
    "Order_number" integer NOT NULL,
    article character varying(255),
    order_date date,
    delivery_date date,
    collect_point_address integer,
    client_fullname integer,
    collect_code integer,
    status_fk integer
);


ALTER TABLE public.orders OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 25042)
-- Name: postavshik; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.postavshik (
    id integer NOT NULL,
    postavshik_pk character varying(155)
);


ALTER TABLE public.postavshik OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 25045)
-- Name: postavshik_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.postavshik_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.postavshik_id_seq OWNER TO postgres;

--
-- TOC entry 4998 (class 0 OID 0)
-- Dependencies: 226
-- Name: postavshik_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.postavshik_id_seq OWNED BY public.postavshik.id;


--
-- TOC entry 227 (class 1259 OID 25046)
-- Name: proizvoditel; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.proizvoditel (
    id integer NOT NULL,
    proizvoditel_pk character varying(155)
);


ALTER TABLE public.proizvoditel OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 25049)
-- Name: proizvoditel_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.proizvoditel_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.proizvoditel_id_seq OWNER TO postgres;

--
-- TOC entry 4999 (class 0 OID 0)
-- Dependencies: 228
-- Name: proizvoditel_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.proizvoditel_id_seq OWNED BY public.proizvoditel.id;


--
-- TOC entry 229 (class 1259 OID 25050)
-- Name: roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roles (
    id_role integer NOT NULL,
    role_name character varying(255)
);


ALTER TABLE public.roles OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 25053)
-- Name: roles_id_role_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.roles_id_role_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.roles_id_role_seq OWNER TO postgres;

--
-- TOC entry 5000 (class 0 OID 0)
-- Dependencies: 230
-- Name: roles_id_role_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.roles_id_role_seq OWNED BY public.roles.id_role;


--
-- TOC entry 231 (class 1259 OID 25054)
-- Name: status; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.status (
    status_id integer NOT NULL,
    status_name character varying(55)
);


ALTER TABLE public.status OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 25057)
-- Name: tovar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tovar (
    id_article character varying(155) NOT NULL,
    name_tovar_fk integer,
    edinitca_izm character varying(15),
    sale bigint,
    postavshik_fk integer,
    proizvoditel_fk integer,
    category_fk integer,
    discount integer,
    quantity integer,
    opisanie character varying(255),
    picture character varying(155)
);


ALTER TABLE public.tovar OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 25062)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    role_fk integer,
    "Full_name" character varying(255),
    "Login" character varying(255),
    "Password" character varying(55),
    id integer NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 25067)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 5001 (class 0 OID 0)
-- Dependencies: 234
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 4788 (class 2604 OID 25068)
-- Name: category id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.category ALTER COLUMN id SET DEFAULT nextval('public.category_id_seq'::regclass);


--
-- TOC entry 4789 (class 2604 OID 25069)
-- Name: name_tovar id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.name_tovar ALTER COLUMN id SET DEFAULT nextval('public.name_tovar_id_seq'::regclass);


--
-- TOC entry 4790 (class 2604 OID 25070)
-- Name: order_product id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_product ALTER COLUMN id SET DEFAULT nextval('public.order_product_id_seq'::regclass);


--
-- TOC entry 4791 (class 2604 OID 25071)
-- Name: postavshik id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.postavshik ALTER COLUMN id SET DEFAULT nextval('public.postavshik_id_seq'::regclass);


--
-- TOC entry 4792 (class 2604 OID 25072)
-- Name: proizvoditel id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.proizvoditel ALTER COLUMN id SET DEFAULT nextval('public.proizvoditel_id_seq'::regclass);


--
-- TOC entry 4793 (class 2604 OID 25073)
-- Name: roles id_role; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles ALTER COLUMN id_role SET DEFAULT nextval('public.roles_id_role_seq'::regclass);


--
-- TOC entry 4794 (class 2604 OID 25074)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 4972 (class 0 OID 25022)
-- Dependencies: 217
-- Data for Name: category; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.category (id, category_pk) FROM stdin;
1	Женская обувь
2	Мужская обувь
\.


--
-- TOC entry 4974 (class 0 OID 25026)
-- Dependencies: 219
-- Data for Name: claim_points_addresses; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.claim_points_addresses (id, address) FROM stdin;
1	420151. г. Лесной. ул. Вишневая. 32
2	125061. г. Лесной. ул. Подгорная. 8
3	630370. г. Лесной. ул. Шоссейная. 24
4	400562. г. Лесной. ул. Зеленая. 32
5	614510. г. Лесной. ул. Маяковского. 47
6	410542. г. Лесной. ул. Светлая. 46
7	620839. г. Лесной. ул. Цветочная. 8
8	443890. г. Лесной. ул. Коммунистическая. 1
9	603379. г. Лесной. ул. Спортивная. 46
10	603721. г. Лесной. ул. Гоголя. 41
11	410172. г. Лесной. ул. Северная. 13
12	614611. г. Лесной. ул. Молодежная. 50
13	454311. г.Лесной. ул. Новая. 19
14	660007. г.Лесной. ул. Октябрьская. 19
15	603036. г. Лесной. ул. Садовая. 4
16	394060. г.Лесной. ул. Фрунзе. 43
17	410661. г. Лесной. ул. Школьная. 50
18	625590. г. Лесной. ул. Коммунистическая. 20
19	625683. г. Лесной. ул. 8 Марта
20	450983. г.Лесной. ул. Комсомольская. 26
21	394782. г. Лесной. ул. Чехова. 3
22	603002. г. Лесной. ул. Дзержинского. 28
23	450558. г. Лесной. ул. Набережная. 30
24	344288. г. Лесной. ул. Чехова. 1
25	614164. г.Лесной.  ул. Степная. 30
26	394242. г. Лесной. ул. Коммунистическая. 43
27	660540. г. Лесной. ул. Солнечная. 25
28	125837. г. Лесной. ул. Шоссейная. 40
29	125703. г. Лесной. ул. Партизанская. 49
30	625283. г. Лесной. ул. Победы. 46
31	614753. г. Лесной. ул. Полевая. 35
32	426030. г. Лесной. ул. Маяковского. 44
33	450375. г. Лесной ул. Клубная. 44
34	625560. г. Лесной. ул. Некрасова. 12
35	630201. г. Лесной. ул. Комсомольская. 17
36	190949. г. Лесной. ул. Мичурина. 26
\.


--
-- TOC entry 4975 (class 0 OID 25031)
-- Dependencies: 220
-- Data for Name: name_tovar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.name_tovar (id, name_tovar_pk) FROM stdin;
1	Ботинки
2	Туфли
3	Кроссовки
4	Полуботинки
5	Кеды
6	Тапочки
7	Сапоги
8	1111
\.


--
-- TOC entry 4977 (class 0 OID 25035)
-- Dependencies: 222
-- Data for Name: order_product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.order_product (id, order_id, article_fk, quantity) FROM stdin;
\.


--
-- TOC entry 4979 (class 0 OID 25039)
-- Dependencies: 224
-- Data for Name: orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.orders ("Order_number", article, order_date, delivery_date, collect_point_address, client_fullname, collect_code, status_fk) FROM stdin;
1	А112Т4. 2. F635R4. 2	2025-02-27	2025-04-20	1	4	901	1
2	H782T5. 1. G783F5. 1	2022-09-28	2025-04-21	11	1	902	1
3	J384T6. 10. D572U8. 10	2025-03-21	2025-04-22	2	2	903	1
4	F572H7. 5. D329H3. 4	2025-02-20	2025-04-23	11	3	904	1
5	А112Т4. 2. F635R4. 2	2025-03-17	2025-04-24	2	4	905	1
6	H782T5. 1. G783F5. 1	2025-03-01	2025-04-25	15	1	906	1
7	J384T6. 10. D572U8. 10	2025-02-28	2025-04-26	3	2	907	1
8	F572H7. 5. D329H3. 4	2025-03-31	2025-04-27	19	3	908	2
9	B320R5. 5. G432E4. 1	2025-04-02	2025-04-28	5	4	909	2
10	S213E3. 5. E482R4. 5	2025-04-03	2025-04-29	19	4	910	2
11	\N	2025-12-26	2025-12-27	24	\N	\N	2
\.


--
-- TOC entry 4980 (class 0 OID 25042)
-- Dependencies: 225
-- Data for Name: postavshik; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.postavshik (id, postavshik_pk) FROM stdin;
1	Kari
2	Обувь для вас
\.


--
-- TOC entry 4982 (class 0 OID 25046)
-- Dependencies: 227
-- Data for Name: proizvoditel; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.proizvoditel (id, proizvoditel_pk) FROM stdin;
1	Kari
2	Marco Tozzi
3	Рос
4	Rieker
5	Alessio Nesca
6	CROSBY
\.


--
-- TOC entry 4984 (class 0 OID 25050)
-- Dependencies: 229
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.roles (id_role, role_name) FROM stdin;
1	Администратор
2	Менеджер
3	Авторизированный клиент
\.


--
-- TOC entry 4986 (class 0 OID 25054)
-- Dependencies: 231
-- Data for Name: status; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.status (status_id, status_name) FROM stdin;
1	Завершен
2	Новый 
\.


--
-- TOC entry 4987 (class 0 OID 25057)
-- Dependencies: 232
-- Data for Name: tovar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tovar (id_article, name_tovar_fk, edinitca_izm, sale, postavshik_fk, proizvoditel_fk, category_fk, discount, quantity, opisanie, picture) FROM stdin;
E482R4	4	шт.	1800	1	1	1	2	14	Полуботинки kari женские MYZ20S-149, размер 41, цвет: черный	C:\\Users\\maksi\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\c20745fb-1e13-40d4-91e7-eabed0872e9e.png
H782T5	2	шт.	4499	1	1	2	4	5	Туфли kari мужские классика MYZ21AW-450A, размер 43, цвет: черный	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\fbae7ca4-c694-4ab2-83b5-19ca06f00c5e.png
G783F5	1	шт.	5900	1	3	2	2	8	Мужские ботинки Рос-Обувь кожаные с натуральным мехом	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\457efef1-e164-4534-baaf-f8fd8a9dc65d.png
J384T6	2	шт.	3800	2	4	2	2	16	B3430/14 Полуботинки мужские Rieker	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\b54ada8d-edc9-4e39-a7fb-79c10e5b52ca.png
D572U8	3	шт.	4100	2	3	2	3	6	129615-4 Кроссовки мужские	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\b3ae9239-ae7b-4a52-a4ec-f7af89aa2530.png
F572H7	2	шт.	2700	1	2	1	2	14	Туфли Marco Tozzi женские летние, размер 39, цвет черный	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\cb1d55e9-ac02-400a-bdfd-2da0473136a9.png
D329H3	4	шт.	1890	2	5	1	4	4	Полуботинки Alessio Nesca женские 3-30797-47, размер 37, цвет: бордовый	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\747030bc-ba02-4a44-a603-045ff419348d.png
B320R5	2	шт.	4300	1	4	1	2	6	Туфли Rieker женские демисезонные, размер 41, цвет коричневый	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\3d431236-ea11-4c00-af7c-2e41f4e1d4f1.png
G432E4	2	шт.	2800	1	1	1	3	15	Туфли kari женские TR-YR-413017, размер 37, цвет: черный	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\e4efd3c4-480b-4a4d-acff-512ce1fb28f7.png
J542F5	6	шт.	500	1	1	2	13	0	Тапочки мужские Арт.70701-55-67син р.41	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\5ac22931-e2b5-4b93-9d42-f9021be5c538.png
S634B5	5	шт.	5500	2	6	2	3	0	Кеды Caprice мужские демисезонные, размер 42, цвет черный	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\7dbe1817-0459-4e19-89a9-6a1acbf51336.png
K358H6	6	шт.	599	1	4	2	20	2	Тапочки мужские син р.41	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\c9ae8847-c58c-4e1e-a207-1d9cb0087876.png
M542T5	3	шт.	2800	2	4	2	18	3	Кроссовки мужские TOFA	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\93d511d9-c489-4333-b677-2a602f0857df.png
K345R4	4	шт.	2100	2	6	2	2	3	407700/01-02 Полуботинки мужские CROSBY	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\8a5fe568-47d6-490e-b3d0-0030c8fd9309.png
T324F5	7	шт.	4699	1	6	1	2	5	Сапоги замша Цвет: синий	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\113f2a4f-c3bb-4736-9fda-2c0b06e0c4a9.png
B431R5	1	шт.	2700	2	4	2	2	5	Мужские кожаные ботинки/мужские ботинки	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\d9ff2b07-5ead-4eea-a0cd-078700a17cee.png
D364R4	2	шт.	12400	1	1	1	16	5	Туфли Luiza Belly женские Kate-lazo черные из натуральной замши	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\5442de2a-9a62-4d89-b6a2-eaf6dec2e094.png
S213E3	4	шт.	2156	2	6	2	3	6	407700/01-01 Полуботинки мужские CROSBY	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\80d7625d-4e44-4783-a9c5-1c9c5921b471.png
L754R4	4	шт.	1700	1	1	1	2	7	Полуботинки kari женские WB2020SS-26, размер 38, цвет: черный	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\86b60a2b-8077-48f5-b3c0-bb818e274316.png
H535R5	1	шт.	2300	2	4	1	2	7	Женские Ботинки демисезонные	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\7fd7bcc2-9880-4f37-af6a-0821400ce253.png
C436G5	1	шт.	10200	1	5	1	15	9	Ботинки женские, ARGO, размер 40	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\3d70514d-4cc0-4e70-b78e-59200d3d3e95.png
F427R5	1	шт.	11800	2	4	1	15	11	Ботинки на молнии с декоративной пряжкой FRAU	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\e9e59fde-84a8-42b8-ac59-939e5fbb1222.png
D268G5	2	шт.	4399	2	4	1	3	12	Туфли Rieker женские демисезонные, размер 36, цвет коричневый	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\f1d0942e-7305-47ba-a081-99c0a986a977.png
N457T5	4	шт.	4600	1	6	1	3	13	Полуботинки Ботинки черные зимние, мех	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\f0144490-9e78-40fc-bec1-0aacf13af7f9.png
P764G4	2	шт.	6800	1	6	1	15	15	Туфли женские, ARGO, размер 38	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\b0ddad05-038d-48ad-85e8-3c10399c68e4.png
А112Т4	1	шт.	4990	1	1	1	3	6	Женские Ботинки демисезонные kari	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\9468adfb-0044-40ef-93a5-870a90bee729.png
F635R4	1	шт.	3244	2	2	1	2	13	Ботинки Marco Tozzi женские демисезонные, размер 39, цвет бежевый	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\4d46d76d-d6bf-4d10-b3f6-0176331fedb1.png
O754F4	2	шт.	5400	2	4	1	4	18	Туфли женские демисезонные Rieker артикул 55073-68/37	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\646549b5-94c3-406a-bc58-537119cfbbad.png
S326R5	6	шт.	9900	2	6	2	17	15	Мужские кожаные тапочки Профиль С.Дали 	C:\\Users\\monderix\\source\\repos\\ShoeStoreDemo\\ShoeStoreDemo\\bin\\Debug\\net8.0-windows\\Images\\29f3e2f4-175b-4613-bcf8-ac83bd73a3b1.png
eadb70b9-1287-4ad4-bd18-05ecee0b8d6b	\N	шт.	1111	\N	\N	\N	10	30	ываыыва	
ad976f07-6a2b-46e7-8c9d-cf5e04f1af3e	\N	шт.	10000	\N	\N	\N	15	30	Дадададада	
\.


--
-- TOC entry 4988 (class 0 OID 25062)
-- Dependencies: 233
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (role_fk, "Full_name", "Login", "Password", id) FROM stdin;
1	Никифорова Весения Николаевна	94d5ous@gmail.com	uzWC67	1
1	Сазонов Руслан Германович	uth4iz@mail.com	2L6KZG	2
1	Одинцов Серафим Артёмович	yzls62@outlook.com	JlFRCZ	3
2	Степанов Михаил Артёмович	1diph5e@tutanota.com	8ntwUp	4
2	Ворсин Петр Евгеньевич	tjde7c@yahoo.com	YOyhfR	5
2	Старикова Елена Павловна	wpmrc3do@tutanota.com	RSbvHv	6
3	Михайлюк Анна Вячеславовна	5d4zbu@tutanota.com	rwVDh9	7
3	Ситдикова Елена Анатольевна	ptec8ym@yahoo.com	LdNyos	8
3	Ворсин Петр Евгеньевич	1qz4kw@mail.com	gynQMT	9
3	Старикова Елена Павловна	4np6se@mail.com	AtnDjr	10
1	1	1	1	11
2	2	2	2	12
3	3	3	3	13
\.


--
-- TOC entry 5002 (class 0 OID 0)
-- Dependencies: 218
-- Name: category_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.category_id_seq', 1, false);


--
-- TOC entry 5003 (class 0 OID 0)
-- Dependencies: 221
-- Name: name_tovar_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.name_tovar_id_seq', 8, true);


--
-- TOC entry 5004 (class 0 OID 0)
-- Dependencies: 223
-- Name: order_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.order_product_id_seq', 1, false);


--
-- TOC entry 5005 (class 0 OID 0)
-- Dependencies: 226
-- Name: postavshik_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.postavshik_id_seq', 1, false);


--
-- TOC entry 5006 (class 0 OID 0)
-- Dependencies: 228
-- Name: proizvoditel_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.proizvoditel_id_seq', 1, false);


--
-- TOC entry 5007 (class 0 OID 0)
-- Dependencies: 230
-- Name: roles_id_role_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.roles_id_role_seq', 1, false);


--
-- TOC entry 5008 (class 0 OID 0)
-- Dependencies: 234
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 10, true);


--
-- TOC entry 4796 (class 2606 OID 25076)
-- Name: category category_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (id);


--
-- TOC entry 4798 (class 2606 OID 25078)
-- Name: claim_points_addresses claim_points_addresses_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.claim_points_addresses
    ADD CONSTRAINT claim_points_addresses_pkey PRIMARY KEY (id);


--
-- TOC entry 4800 (class 2606 OID 25080)
-- Name: name_tovar name_tovar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.name_tovar
    ADD CONSTRAINT name_tovar_pkey PRIMARY KEY (id);


--
-- TOC entry 4802 (class 2606 OID 25082)
-- Name: order_product order_product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_product
    ADD CONSTRAINT order_product_pkey PRIMARY KEY (id);


--
-- TOC entry 4804 (class 2606 OID 25084)
-- Name: orders orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY ("Order_number");


--
-- TOC entry 4806 (class 2606 OID 25086)
-- Name: postavshik postavshik_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.postavshik
    ADD CONSTRAINT postavshik_pkey PRIMARY KEY (id);


--
-- TOC entry 4808 (class 2606 OID 25088)
-- Name: proizvoditel proizvoditel_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.proizvoditel
    ADD CONSTRAINT proizvoditel_pkey PRIMARY KEY (id);


--
-- TOC entry 4810 (class 2606 OID 25090)
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id_role);


--
-- TOC entry 4812 (class 2606 OID 25092)
-- Name: status status_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.status
    ADD CONSTRAINT status_pkey PRIMARY KEY (status_id);


--
-- TOC entry 4814 (class 2606 OID 25094)
-- Name: tovar tovar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tovar
    ADD CONSTRAINT tovar_pkey PRIMARY KEY (id_article);


--
-- TOC entry 4816 (class 2606 OID 25096)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4817 (class 2606 OID 25097)
-- Name: order_product order_product_article_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_product
    ADD CONSTRAINT order_product_article_fk_fkey FOREIGN KEY (article_fk) REFERENCES public.tovar(id_article) NOT VALID;


--
-- TOC entry 4818 (class 2606 OID 25102)
-- Name: order_product order_product_order_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_product
    ADD CONSTRAINT order_product_order_id_fkey FOREIGN KEY (order_id) REFERENCES public.orders("Order_number") NOT VALID;


--
-- TOC entry 4819 (class 2606 OID 25107)
-- Name: orders orders_client_fullname_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_client_fullname_fkey FOREIGN KEY (client_fullname) REFERENCES public.users(id) NOT VALID;


--
-- TOC entry 4820 (class 2606 OID 25112)
-- Name: orders orders_collect_point_address_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_collect_point_address_fkey FOREIGN KEY (collect_point_address) REFERENCES public.claim_points_addresses(id) NOT VALID;


--
-- TOC entry 4821 (class 2606 OID 25117)
-- Name: orders orders_status_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_status_fk_fkey FOREIGN KEY (status_fk) REFERENCES public.status(status_id) NOT VALID;


--
-- TOC entry 4822 (class 2606 OID 25122)
-- Name: tovar tovar_category_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tovar
    ADD CONSTRAINT tovar_category_fk_fkey FOREIGN KEY (category_fk) REFERENCES public.category(id) NOT VALID;


--
-- TOC entry 4823 (class 2606 OID 25127)
-- Name: tovar tovar_name_tovar_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tovar
    ADD CONSTRAINT tovar_name_tovar_fk_fkey FOREIGN KEY (name_tovar_fk) REFERENCES public.name_tovar(id) NOT VALID;


--
-- TOC entry 4824 (class 2606 OID 25132)
-- Name: tovar tovar_postavshik_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tovar
    ADD CONSTRAINT tovar_postavshik_fk_fkey FOREIGN KEY (postavshik_fk) REFERENCES public.postavshik(id) NOT VALID;


--
-- TOC entry 4825 (class 2606 OID 25137)
-- Name: tovar tovar_proizvoditel_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tovar
    ADD CONSTRAINT tovar_proizvoditel_fk_fkey FOREIGN KEY (proizvoditel_fk) REFERENCES public.proizvoditel(id) NOT VALID;


--
-- TOC entry 4826 (class 2606 OID 25142)
-- Name: users users_role_fk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_role_fk_fkey FOREIGN KEY (role_fk) REFERENCES public.roles(id_role) NOT VALID;


-- Completed on 2026-03-30 21:18:14

--
-- PostgreSQL database dump complete
--

\unrestrict j6X5S7bj0wpyoSjYAbVVnnpCaqE99vbRBqg9at3pXiWCow3KgDaElB8XX88tEu7

