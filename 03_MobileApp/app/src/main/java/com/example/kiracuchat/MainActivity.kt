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

        val userOptionBtn: Button = findViewById(R.id.user_option_btn)
        val channelBtn: Button = findViewById(R.id.channel_btn)

        userOptionBtn.setOnClickListener {
            startActivity(Intent(this, UserOptionActivity::class.java))
        }
        channelBtn.setOnClickListener {
            startActivity(Intent(this, channel::class.java))
        }

    }

    fun buttonOnClick(view: View){ // ①クリック時の処理を追加
        val textView: TextView = findViewById(R.id.textView)
        textView.text = "";

        lifecycleScope.launch(Dispatchers.IO) {  // ②コルーチンで非同期処理
            val contestApiClient = ContestApiClient()
            val pingResponse = contestApiClient.ping()

            withContext(Dispatchers.Main) {  // ③UIスレッドで結果を反映
                if (pingResponse != null) {
                    textView.text = "ping() success: ${pingResponse.message}"
                } else {
                    textView.text = "ping() failed"
                }
            }
        }
        //トーストボタン
        val btn1: Button = findViewById(R.id.button2)
        btn1.setOnClickListener {
            val context: Context = applicationContext
            val text = "トーストが表示されました。"
            val duration = Toast.LENGTH_SHORT
            Toast.makeText(context, text, duration).show()
        }
    }
}
