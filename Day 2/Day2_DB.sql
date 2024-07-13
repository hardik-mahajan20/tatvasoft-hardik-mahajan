PGDMP      )                |            Introduction_DB    16.3    16.3 =    :           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ;           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            <           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            =           1262    17128    Introduction_DB    DATABASE     �   CREATE DATABASE "Introduction_DB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
 !   DROP DATABASE "Introduction_DB";
                postgres    false            �            1259    17137    city    TABLE     �   CREATE TABLE public.city (
    city_id integer NOT NULL,
    country_id integer NOT NULL,
    city_name character varying(100) NOT NULL
);
    DROP TABLE public.city;
       public         heap    postgres    false            �            1259    17136    city_city_id_seq    SEQUENCE     �   CREATE SEQUENCE public.city_city_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.city_city_id_seq;
       public          postgres    false    218            >           0    0    city_city_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.city_city_id_seq OWNED BY public.city.city_id;
          public          postgres    false    217            �            1259    17130    country    TABLE     s   CREATE TABLE public.country (
    country_id integer NOT NULL,
    country_name character varying(100) NOT NULL
);
    DROP TABLE public.country;
       public         heap    postgres    false            �            1259    17129    country_country_id_seq    SEQUENCE     �   CREATE SEQUENCE public.country_country_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.country_country_id_seq;
       public          postgres    false    216            ?           0    0    country_country_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.country_country_id_seq OWNED BY public.country.country_id;
          public          postgres    false    215            �            1259    17169    mission_application    TABLE     �   CREATE TABLE public.mission_application (
    mission_app_id integer NOT NULL,
    mission_id integer NOT NULL,
    applied_date timestamp with time zone DEFAULT now() NOT NULL,
    status boolean,
    sheets integer NOT NULL,
    user_id integer
);
 '   DROP TABLE public.mission_application;
       public         heap    postgres    false            �            1259    17168 &   mission_application_mission_app_id_seq    SEQUENCE     �   CREATE SEQUENCE public.mission_application_mission_app_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 =   DROP SEQUENCE public.mission_application_mission_app_id_seq;
       public          postgres    false    222            @           0    0 &   mission_application_mission_app_id_seq    SEQUENCE OWNED BY     q   ALTER SEQUENCE public.mission_application_mission_app_id_seq OWNED BY public.mission_application.mission_app_id;
          public          postgres    false    221            �            1259    17181    mission_skill    TABLE     �   CREATE TABLE public.mission_skill (
    mission_skill_id integer NOT NULL,
    skill_name character varying(100),
    status character varying(100)
);
 !   DROP TABLE public.mission_skill;
       public         heap    postgres    false            �            1259    17186    mission_theme    TABLE     �   CREATE TABLE public.mission_theme (
    mission_theme_id integer NOT NULL,
    theme_name character varying(100),
    status character varying(100)
);
 !   DROP TABLE public.mission_theme;
       public         heap    postgres    false            �            1259    17149    missions    TABLE       CREATE TABLE public.missions (
    mission_id integer NOT NULL,
    mission_title character varying(100),
    mission_description character varying(400),
    mission_org_name character varying(100),
    mission_org_detail character varying(400),
    country_id integer NOT NULL,
    city_id integer NOT NULL,
    start_date timestamp with time zone DEFAULT now() NOT NULL,
    end_date timestamp with time zone,
    mission_type character varying(100),
    total_sheets integer NOT NULL,
    registration_deadline timestamp with time zone,
    mission_images character varying(200),
    mission_documents character varying(200),
    mission_availability character varying(200),
    mission_video_url character varying(200),
    mission_theme_id integer,
    mission_skill_id integer
);
    DROP TABLE public.missions;
       public         heap    postgres    false            �            1259    17148    missions_mission_id_seq    SEQUENCE     �   CREATE SEQUENCE public.missions_mission_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.missions_mission_id_seq;
       public          postgres    false    220            A           0    0    missions_mission_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.missions_mission_id_seq OWNED BY public.missions.mission_id;
          public          postgres    false    219            �            1259    17202    user_detail    TABLE     �  CREATE TABLE public.user_detail (
    user_detail_id integer NOT NULL,
    user_id integer NOT NULL,
    name character varying(100) NOT NULL,
    surname character varying(100) NOT NULL,
    employee_id character varying(100) NOT NULL,
    manager character varying(100) NOT NULL,
    title character varying(100) NOT NULL,
    department character varying(100) NOT NULL,
    my_profile character varying(500) NOT NULL,
    whyivolunteer character varying(500) NOT NULL,
    country_id integer NOT NULL,
    city_id integer NOT NULL,
    availability character varying(100) NOT NULL,
    linkdinurl character varying(300) NOT NULL,
    my_skills character varying(500) NOT NULL,
    user_image character varying(500) NOT NULL,
    status boolean
);
    DROP TABLE public.user_detail;
       public         heap    postgres    false            �            1259    17226    user_skills    TABLE     �   CREATE TABLE public.user_skills (
    user_skill_id integer NOT NULL,
    user_id integer NOT NULL,
    skill character varying(300) NOT NULL
);
    DROP TABLE public.user_skills;
       public         heap    postgres    false            �            1259    17191    users    TABLE     ]  CREATE TABLE public.users (
    user_id integer NOT NULL,
    first_name character varying(100) NOT NULL,
    last_name character varying(100) NOT NULL,
    phone_number character varying(100) NOT NULL,
    email_address character varying(250) NOT NULL,
    user_type character varying(100) NOT NULL,
    password character varying(100) NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false            t           2604    17140    city city_id    DEFAULT     l   ALTER TABLE ONLY public.city ALTER COLUMN city_id SET DEFAULT nextval('public.city_city_id_seq'::regclass);
 ;   ALTER TABLE public.city ALTER COLUMN city_id DROP DEFAULT;
       public          postgres    false    218    217    218            s           2604    17133    country country_id    DEFAULT     x   ALTER TABLE ONLY public.country ALTER COLUMN country_id SET DEFAULT nextval('public.country_country_id_seq'::regclass);
 A   ALTER TABLE public.country ALTER COLUMN country_id DROP DEFAULT;
       public          postgres    false    215    216    216            w           2604    17172 "   mission_application mission_app_id    DEFAULT     �   ALTER TABLE ONLY public.mission_application ALTER COLUMN mission_app_id SET DEFAULT nextval('public.mission_application_mission_app_id_seq'::regclass);
 Q   ALTER TABLE public.mission_application ALTER COLUMN mission_app_id DROP DEFAULT;
       public          postgres    false    221    222    222            u           2604    17152    missions mission_id    DEFAULT     z   ALTER TABLE ONLY public.missions ALTER COLUMN mission_id SET DEFAULT nextval('public.missions_mission_id_seq'::regclass);
 B   ALTER TABLE public.missions ALTER COLUMN mission_id DROP DEFAULT;
       public          postgres    false    219    220    220            .          0    17137    city 
   TABLE DATA           >   COPY public.city (city_id, country_id, city_name) FROM stdin;
    public          postgres    false    218   �Q       ,          0    17130    country 
   TABLE DATA           ;   COPY public.country (country_id, country_name) FROM stdin;
    public          postgres    false    216   �Q       2          0    17169    mission_application 
   TABLE DATA           p   COPY public.mission_application (mission_app_id, mission_id, applied_date, status, sheets, user_id) FROM stdin;
    public          postgres    false    222   �Q       3          0    17181    mission_skill 
   TABLE DATA           M   COPY public.mission_skill (mission_skill_id, skill_name, status) FROM stdin;
    public          postgres    false    223    R       4          0    17186    mission_theme 
   TABLE DATA           M   COPY public.mission_theme (mission_theme_id, theme_name, status) FROM stdin;
    public          postgres    false    224   R       0          0    17149    missions 
   TABLE DATA           F  COPY public.missions (mission_id, mission_title, mission_description, mission_org_name, mission_org_detail, country_id, city_id, start_date, end_date, mission_type, total_sheets, registration_deadline, mission_images, mission_documents, mission_availability, mission_video_url, mission_theme_id, mission_skill_id) FROM stdin;
    public          postgres    false    220   :R       6          0    17202    user_detail 
   TABLE DATA           �   COPY public.user_detail (user_detail_id, user_id, name, surname, employee_id, manager, title, department, my_profile, whyivolunteer, country_id, city_id, availability, linkdinurl, my_skills, user_image, status) FROM stdin;
    public          postgres    false    226   WR       7          0    17226    user_skills 
   TABLE DATA           D   COPY public.user_skills (user_skill_id, user_id, skill) FROM stdin;
    public          postgres    false    227   tR       5          0    17191    users 
   TABLE DATA           q   COPY public.users (user_id, first_name, last_name, phone_number, email_address, user_type, password) FROM stdin;
    public          postgres    false    225   �R       B           0    0    city_city_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.city_city_id_seq', 1, false);
          public          postgres    false    217            C           0    0    country_country_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.country_country_id_seq', 1, false);
          public          postgres    false    215            D           0    0 &   mission_application_mission_app_id_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('public.mission_application_mission_app_id_seq', 1, false);
          public          postgres    false    221            E           0    0    missions_mission_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.missions_mission_id_seq', 1, false);
          public          postgres    false    219            |           2606    17142    city city_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public.city
    ADD CONSTRAINT city_pkey PRIMARY KEY (city_id);
 8   ALTER TABLE ONLY public.city DROP CONSTRAINT city_pkey;
       public            postgres    false    218            z           2606    17135    country country_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.country
    ADD CONSTRAINT country_pkey PRIMARY KEY (country_id);
 >   ALTER TABLE ONLY public.country DROP CONSTRAINT country_pkey;
       public            postgres    false    216            �           2606    17175 ,   mission_application mission_application_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public.mission_application
    ADD CONSTRAINT mission_application_pkey PRIMARY KEY (mission_app_id);
 V   ALTER TABLE ONLY public.mission_application DROP CONSTRAINT mission_application_pkey;
       public            postgres    false    222            �           2606    17185     mission_skill mission_skill_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.mission_skill
    ADD CONSTRAINT mission_skill_pkey PRIMARY KEY (mission_skill_id);
 J   ALTER TABLE ONLY public.mission_skill DROP CONSTRAINT mission_skill_pkey;
       public            postgres    false    223            �           2606    17190     mission_theme mission_theme_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.mission_theme
    ADD CONSTRAINT mission_theme_pkey PRIMARY KEY (mission_theme_id);
 J   ALTER TABLE ONLY public.mission_theme DROP CONSTRAINT mission_theme_pkey;
       public            postgres    false    224            ~           2606    17157    missions missions_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.missions
    ADD CONSTRAINT missions_pkey PRIMARY KEY (mission_id);
 @   ALTER TABLE ONLY public.missions DROP CONSTRAINT missions_pkey;
       public            postgres    false    220            �           2606    17210 '   user_detail user_detail_employee_id_key 
   CONSTRAINT     i   ALTER TABLE ONLY public.user_detail
    ADD CONSTRAINT user_detail_employee_id_key UNIQUE (employee_id);
 Q   ALTER TABLE ONLY public.user_detail DROP CONSTRAINT user_detail_employee_id_key;
       public            postgres    false    226            �           2606    17208    user_detail user_detail_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.user_detail
    ADD CONSTRAINT user_detail_pkey PRIMARY KEY (user_detail_id);
 F   ALTER TABLE ONLY public.user_detail DROP CONSTRAINT user_detail_pkey;
       public            postgres    false    226            �           2606    17230    user_skills user_skills_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public.user_skills
    ADD CONSTRAINT user_skills_pkey PRIMARY KEY (user_skill_id);
 F   ALTER TABLE ONLY public.user_skills DROP CONSTRAINT user_skills_pkey;
       public            postgres    false    227            �           2606    17201    users users_email_address_key 
   CONSTRAINT     a   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_address_key UNIQUE (email_address);
 G   ALTER TABLE ONLY public.users DROP CONSTRAINT users_email_address_key;
       public            postgres    false    225            �           2606    17199    users users_phone_number_key 
   CONSTRAINT     _   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_phone_number_key UNIQUE (phone_number);
 F   ALTER TABLE ONLY public.users DROP CONSTRAINT users_phone_number_key;
       public            postgres    false    225            �           2606    17197    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    225            �           2606    17143    city city_country_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.city
    ADD CONSTRAINT city_country_id_fkey FOREIGN KEY (country_id) REFERENCES public.country(country_id);
 C   ALTER TABLE ONLY public.city DROP CONSTRAINT city_country_id_fkey;
       public          postgres    false    218    216    4730            �           2606    17176 7   mission_application mission_application_mission_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.mission_application
    ADD CONSTRAINT mission_application_mission_id_fkey FOREIGN KEY (mission_id) REFERENCES public.missions(mission_id);
 a   ALTER TABLE ONLY public.mission_application DROP CONSTRAINT mission_application_mission_id_fkey;
       public          postgres    false    4734    222    220            �           2606    17236 4   mission_application mission_application_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.mission_application
    ADD CONSTRAINT mission_application_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id);
 ^   ALTER TABLE ONLY public.mission_application DROP CONSTRAINT mission_application_user_id_fkey;
       public          postgres    false    225    222    4746            �           2606    17163    missions missions_city_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.missions
    ADD CONSTRAINT missions_city_id_fkey FOREIGN KEY (city_id) REFERENCES public.city(city_id);
 H   ALTER TABLE ONLY public.missions DROP CONSTRAINT missions_city_id_fkey;
       public          postgres    false    220    4732    218            �           2606    17158 !   missions missions_country_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.missions
    ADD CONSTRAINT missions_country_id_fkey FOREIGN KEY (country_id) REFERENCES public.country(country_id);
 K   ALTER TABLE ONLY public.missions DROP CONSTRAINT missions_country_id_fkey;
       public          postgres    false    216    4730    220            �           2606    17246 '   missions missions_mission_skill_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.missions
    ADD CONSTRAINT missions_mission_skill_id_fkey FOREIGN KEY (mission_skill_id) REFERENCES public.mission_skill(mission_skill_id);
 Q   ALTER TABLE ONLY public.missions DROP CONSTRAINT missions_mission_skill_id_fkey;
       public          postgres    false    223    4738    220            �           2606    17241 '   missions missions_mission_theme_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.missions
    ADD CONSTRAINT missions_mission_theme_id_fkey FOREIGN KEY (mission_theme_id) REFERENCES public.mission_theme(mission_theme_id);
 Q   ALTER TABLE ONLY public.missions DROP CONSTRAINT missions_mission_theme_id_fkey;
       public          postgres    false    220    4740    224            �           2606    17221 $   user_detail user_detail_city_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_detail
    ADD CONSTRAINT user_detail_city_id_fkey FOREIGN KEY (city_id) REFERENCES public.city(city_id);
 N   ALTER TABLE ONLY public.user_detail DROP CONSTRAINT user_detail_city_id_fkey;
       public          postgres    false    218    4732    226            �           2606    17216 '   user_detail user_detail_country_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_detail
    ADD CONSTRAINT user_detail_country_id_fkey FOREIGN KEY (country_id) REFERENCES public.country(country_id);
 Q   ALTER TABLE ONLY public.user_detail DROP CONSTRAINT user_detail_country_id_fkey;
       public          postgres    false    4730    226    216            �           2606    17211 $   user_detail user_detail_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_detail
    ADD CONSTRAINT user_detail_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id);
 N   ALTER TABLE ONLY public.user_detail DROP CONSTRAINT user_detail_user_id_fkey;
       public          postgres    false    225    226    4746            �           2606    17231 $   user_skills user_skills_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_skills
    ADD CONSTRAINT user_skills_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id);
 N   ALTER TABLE ONLY public.user_skills DROP CONSTRAINT user_skills_user_id_fkey;
       public          postgres    false    227    4746    225            .      x������ � �      ,      x������ � �      2      x������ � �      3      x������ � �      4      x������ � �      0      x������ � �      6      x������ � �      7      x������ � �      5      x������ � �     