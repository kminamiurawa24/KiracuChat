package com.example.kiracuchat.network.base

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object ApiProvider {

    private val retrofit = Retrofit.Builder()
        .baseUrl("https://192.168.40.125:7287/")
        .addConverterFactory(GsonConverterFactory.create())
        .client(BaseApiClient.createOkHttpClient())
        .build()

    fun <T> createService(serviceClass: Class<T>): T {
        return retrofit.create(serviceClass)
    }
}