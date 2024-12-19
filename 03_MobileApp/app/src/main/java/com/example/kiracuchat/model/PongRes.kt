package com.example.kiracuchat.model

import android.os.Build
import androidx.annotation.RequiresApi
import kotlinx.serialization.SerialName
import kotlinx.serialization.Serializable
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

@Serializable
data class PongRes(
    @SerialName("message") val message: String,
    @SerialName("timestamp") val timestamp: String // Stringで受け取る場合
    //@SerialName("timestamp") val timestamp: LocalDateTime? // LocalDateTimeで受け取る場合
) {
    // LocalDateTimeで受け取る場合の変換処理（必要に応じて）
    @RequiresApi(Build.VERSION_CODES.O)
    fun getLocalDateTime(): LocalDateTime? {
        return try {
            LocalDateTime.parse(timestamp, DateTimeFormatter.ISO_DATE_TIME)
        } catch (e: Exception) {
            null // パースに失敗した場合はnullを返す
        }
    }
}