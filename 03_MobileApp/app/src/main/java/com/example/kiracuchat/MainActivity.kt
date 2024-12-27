package com.example.kiracuchat
import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.activity.ComponentActivity
import androidx.lifecycle.lifecycleScope
import com.example.kiracuchat.network.client.ContestApiClient
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.io.BufferedReader
import java.io.IOException
import java.io.InputStream
import java.io.InputStreamReader
import java.net.HttpURLConnection
import java.net.URL


class MainActivity : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val channelBtn: Button = findViewById(R.id.channel_btn)
        val logInBtn: Button = findViewById(R.id.Log_in_btn)

        channelBtn.setOnClickListener {
            startActivity(Intent(this, channel::class.java))
        }
        logInBtn.setOnClickListener {
            startActivity(Intent(this, LogInActivity::class.java))
        }
        CoroutineScope(Dispatchers.IO).launch {
            val result = fetchDataFromServer()
            withContext(Dispatchers.Main){
                showToast(result)
            }
        }
    }

    private suspend fun fetchDataFromServer():String{
        return try{
            val contestApiClient = ContestApiClient()
            val pingResponse = contestApiClient.ping()

            if (pingResponse != null) {
                "サーバとの接続に成功しました。"
            } else {
                "サーバとの接続に失敗しました。: ${pingResponse}"
            }
            } catch (e: Exception) {
                "サーバとの接続に失敗しました。: ${e.message}"
        }
    }

    private fun showToast(message: String){
        val context: Context = applicationContext
        val duration = Toast.LENGTH_SHORT
        Toast.makeText(context, message, duration).show()
    }
}
