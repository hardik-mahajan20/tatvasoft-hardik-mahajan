PGDMP      3                |            Practice    16.3    16.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16942    Practice    DATABASE     }   CREATE DATABASE "Practice" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
    DROP DATABASE "Practice";
                postgres    false            �            1259    16954    customer    TABLE     N  CREATE TABLE public.customer (
    customer_id integer NOT NULL,
    first_name character varying(100) NOT NULL,
    last_name character varying(100) NOT NULL,
    email character varying(255) NOT NULL,
    created_date timestamp with time zone DEFAULT now() NOT NULL,
    updated_date timestamp with time zone,
    active boolean
);
    DROP TABLE public.customer;
       public         heap    postgres    false            �            1259    16953    customer_customer_id_seq    SEQUENCE     �   CREATE SEQUENCE public.customer_customer_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.customer_customer_id_seq;
       public          postgres    false    216            �           0    0    customer_customer_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.customer_customer_id_seq OWNED BY public.customer.customer_id;
          public          postgres    false    215            �            1259    16964    orders    TABLE     �   CREATE TABLE public.orders (
    order_id integer NOT NULL,
    customer_id integer NOT NULL,
    order_date timestamp with time zone DEFAULT now() NOT NULL,
    order_number character varying(50) NOT NULL,
    order_amount numeric(10,2) NOT NULL
);
    DROP TABLE public.orders;
       public         heap    postgres    false            �            1259    16963    orders_order_id_seq    SEQUENCE     �   CREATE SEQUENCE public.orders_order_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.orders_order_id_seq;
       public          postgres    false    218            �           0    0    orders_order_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.orders_order_id_seq OWNED BY public.orders.order_id;
          public          postgres    false    217            U           2604    16957    customer customer_id    DEFAULT     |   ALTER TABLE ONLY public.customer ALTER COLUMN customer_id SET DEFAULT nextval('public.customer_customer_id_seq'::regclass);
 C   ALTER TABLE public.customer ALTER COLUMN customer_id DROP DEFAULT;
       public          postgres    false    215    216    216            W           2604    16967    orders order_id    DEFAULT     r   ALTER TABLE ONLY public.orders ALTER COLUMN order_id SET DEFAULT nextval('public.orders_order_id_seq'::regclass);
 >   ALTER TABLE public.orders ALTER COLUMN order_id DROP DEFAULT;
       public          postgres    false    218    217    218            �          0    16954    customer 
   TABLE DATA           q   COPY public.customer (customer_id, first_name, last_name, email, created_date, updated_date, active) FROM stdin;
    public          postgres    false    216   �       �          0    16964    orders 
   TABLE DATA           _   COPY public.orders (order_id, customer_id, order_date, order_number, order_amount) FROM stdin;
    public          postgres    false    218   L       �           0    0    customer_customer_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.customer_customer_id_seq', 19, true);
          public          postgres    false    215            �           0    0    orders_order_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.orders_order_id_seq', 18, true);
          public          postgres    false    217            Z           2606    16962    customer customer_email_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.customer
    ADD CONSTRAINT customer_email_key UNIQUE (email);
 E   ALTER TABLE ONLY public.customer DROP CONSTRAINT customer_email_key;
       public            postgres    false    216            \           2606    16960    customer customer_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.customer
    ADD CONSTRAINT customer_pkey PRIMARY KEY (customer_id);
 @   ALTER TABLE ONLY public.customer DROP CONSTRAINT customer_pkey;
       public            postgres    false    216            ^           2606    16970    orders orders_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (order_id);
 <   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_pkey;
       public            postgres    false    218            _           2606    16971    orders orders_customer_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_customer_id_fkey FOREIGN KEY (customer_id) REFERENCES public.customer(customer_id);
 H   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_customer_id_fkey;
       public          postgres    false    216    4700    218            �   j  x���MO�0E�7����qڄt�0-HEBHl^�W�`Ǖ�0��8킑FHxw���^(,\���1�����ٽaQ9%��T�R��r�əʅʋ,W?�t�xZ�O2\]1�V�5(p0B5��m�N�k�i!���Z�ܻ�<�&P�(�RW5��3���vI�5y��MXׅ�6rD�3\ҫ��!��m�*`��ĭѯ��$����c�2�X����W��	�y䈃Kܶz�~\ݡ9F�w1���q�޿�,�bt,�V�G����Gۻ����)���w����BM~�_`����c�x�lI���T9K�(���⟡%�n_Wz���K��`�n"gi&�<-���vO"I��Q;�      �   �   x���;�1и|�͇5�X-wǓL��?ǪՉ�@�C�Uf0�d���]9/�K	�aԉ�@**P�nM�U0�ځQ��.�VQ�Iw�GEX7j���Ȭ��Cnz��	�|S���݋���dk����juk�	�k�{����౵�������ZV�ǚao�xZ_�om�����b��v�3�_o���G��     